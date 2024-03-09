/*
 * MIT License
 *Copyright (c) 2021 易开元(Easy-Open-Meta)

 *Permission is hereby granted, free of charge, to any person obtaining a copy
 *of this software and associated documentation files (the "Software"), to deal
 *in the Software without restriction, including without limitation the rights
 *to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *copies of the Software, and to permit persons to whom the Software is
 *furnished to do so, subject to the following conditions:

 *The above copyright notice and this permission notice shall be included in all
 *copies or substantial portions of the Software.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *SOFTWARE.
 *
 */
using EOM.Encrypt;
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SqlSugar;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 员工信息接口实现类
    /// </summary>
    public class WorkerService : IWorkerService
    {
        /// <summary>
        /// 员工信息
        /// </summary>
        private readonly PgRepository<Worker> workerRepository;

        /// <summary>
        /// 性别类型
        /// </summary>
        private readonly PgRepository<SexType> sexTypeRepository;

        /// <summary>
        /// 学历类型
        /// </summary>
        private readonly PgRepository<Education> educationRepository;

        /// <summary>
        /// 民族类型
        /// </summary>
        private readonly PgRepository<Nation> nationRepository;

        /// <summary>
        /// 部门
        /// </summary>
        private readonly PgRepository<Dept> deptRepository;

        /// <summary>
        /// 职务
        /// </summary>
        private readonly PgRepository<Position> positionRepository;

        /// <summary>
        /// 加密
        /// </summary>
        private readonly EOM.Encrypt.Encrypt encrypt;

        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workerRepository"></param>
        /// <param name="sexTypeRepository"></param>
        /// <param name="educationRepository"></param>
        /// <param name="nationRepository"></param>
        /// <param name="deptRepository"></param>
        /// <param name="positionRepository"></param>
        /// <param name="encrypt"></param>
        /// <param name="configuration"></param>
        public WorkerService(PgRepository<Worker> workerRepository, PgRepository<SexType> sexTypeRepository, PgRepository<Education> educationRepository, PgRepository<Nation> nationRepository, PgRepository<Dept> deptRepository, PgRepository<Position> positionRepository, Encrypt.Encrypt encrypt, IConfiguration configuration)
        {
            this.workerRepository = workerRepository;
            this.sexTypeRepository = sexTypeRepository;
            this.educationRepository = educationRepository;
            this.nationRepository = nationRepository;
            this.deptRepository = deptRepository;
            this.positionRepository = positionRepository;
            this.encrypt = encrypt;
            this.configuration = configuration;
        }

        #region 修改员工信息
        /// <summary>
        /// 修改员工信息
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public bool UpdateWorker(Worker worker)
        {
            //加密联系方式
            var sourceTelStr = string.Empty;
            if (!string.IsNullOrEmpty(worker.WorkerTel))
            {
                sourceTelStr = encrypt.Encryption(worker.WorkerTel, EncryptionLevel.Enhanced);
            }
            //加密身份证
            var sourceIdStr = string.Empty;
            if (!string.IsNullOrEmpty(worker.CardId))
            {
                sourceIdStr = encrypt.Encryption(worker.CardId, EncryptionLevel.Enhanced);
            }
            worker.WorkerTel = sourceTelStr;
            worker.CardId = sourceIdStr;
            return workerRepository.Update(a => new Worker()
            {
                WorkerName = worker.WorkerName,
                WorkerTel = worker.WorkerTel,
                WorkerAddress = worker.WorkerAddress,
                WorkerFace = worker.WorkerFace,
                WorkerEducation = worker.WorkerEducation,
                WorkerNation = worker.WorkerNation,
                CardId = worker.CardId,
                WorkerSex = worker.WorkerSex,
                WorkerBirthday = worker.WorkerBirthday,
                datachg_usr = worker.datachg_usr
            }, a => a.WorkerId.Equals(worker.WorkerId));

        }
        #endregion

        /// <summary>
        /// 员工账号禁/启用
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public bool ManagerWorkerAccount(Worker worker)
        {
            return workerRepository.Update(a => new Worker()
            {
                delete_mk = worker.delete_mk
            }, a => a.WorkerId == worker.WorkerId);
        }

        /// <summary>
        /// 更新员工职位和部门
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>

        public bool UpdateWorkerPositionAndClub(Worker worker)
        {
            return workerRepository.Update(a => new Worker()
            {
                WorkerClub = worker.WorkerClub,
                WorkerPosition = worker.WorkerPosition,
                datachg_usr = worker.datachg_usr
            }, a => a.WorkerId == worker.WorkerId);
        }

        #region 添加员工信息
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public bool AddWorker(Worker worker)
        {
            string NewID = encrypt.Encryption(worker.CardId);
            string NewTel = encrypt.Encryption(worker.WorkerTel);
            worker.CardId = NewID;
            worker.WorkerTel = NewTel;
            return workerRepository.Insert(worker);
        }
        #endregion

        #region 获取所有工作人员信息
        /// <summary>
        /// 获取所有工作人员信息
        /// </summary>
        /// <returns></returns>
        public List<Worker> SelectWorkerAll()
        {
            var where = Expressionable.Create<Worker>();

            where = where.And(a => a.delete_mk != 1);

            //查询所有教育程度信息
            List<Education> educations = new List<Education>();
            educations = educationRepository.GetList(a => a.delete_mk != 1);
            //查询所有性别类型信息
            List<SexType> sexTypes = new List<SexType>();
            sexTypes = sexTypeRepository.GetList(a => a.delete_mk != 1);
            //查询所有民族类型信息
            List<Nation> nations = new List<Nation>();
            nations = nationRepository.GetList(a => a.delete_mk != 1);
            //查询所有部门信息
            List<Dept> depts = new List<Dept>();
            depts = deptRepository.GetList(a => a.delete_mk != 1);
            //查询所有职位信息
            List<Position> positions = new List<Position>();
            positions = positionRepository.GetList(a => a.delete_mk != 1);
            //查询所有员工信息
            List<Worker> workers = new List<Worker>();

            workers = workerRepository.GetList(where.ToExpression());
            workers.ForEach(source =>
            {
                //解密身份证号码
                var sourceStr = source.CardId.Contains("·") ? encrypt.Decryption(source.CardId) : source.CardId;
                source.CardId = sourceStr;
                //解密联系方式
                var sourceTelStr = source.WorkerTel.Contains("·") ? encrypt.Decryption(source.WorkerTel) : source.WorkerTel;
                source.WorkerTel = sourceTelStr;
                //性别类型
                var sexType = sexTypes.FirstOrDefault(a => a.sexId == source.WorkerSex);
                source.WorkerSexName = string.IsNullOrEmpty(sexType.sexName) ? "" : sexType.sexName;
                //教育程度
                var eduction = educations.FirstOrDefault(a => a.education_no == source.WorkerEducation);
                source.EducationName = string.IsNullOrEmpty(eduction.education_name) ? "" : eduction.education_name;
                //民族类型
                var nation = nations.FirstOrDefault(a => a.nation_no == source.WorkerNation);
                source.NationName = string.IsNullOrEmpty(nation.nation_name) ? "" : nation.nation_name;
                //部门
                var dept = depts.FirstOrDefault(a => a.dept_no == source.WorkerClub);
                source.ClubName = string.IsNullOrEmpty(dept.dept_name) ? "" : dept.dept_name;
                //职位
                var position = positions.FirstOrDefault(a => a.position_no == source.WorkerPosition);
                source.PositionName = string.IsNullOrEmpty(position.position_name) ? "" : position.position_name;
            });

            return workers;
        }

        /// <summary>
        /// 根据部门ID获取工作人员信息
        /// </summary>
        /// <param name="deptNo"></param>
        /// <returns></returns>
        public bool CheckWorkerBydepartment(string deptNo)
        {
            var workers = workerRepository.Count(a => a.WorkerClub.Equals(deptNo));

            return workers > 0 ? true : false;
        }
        #endregion

        #region 根据登录名称查询员工信息
        /// <summary>
        /// 根据登录名称查询员工信息
        /// </summary>
        /// <param name="workerId"></param>
        /// <returns></returns>
        public Worker SelectWorkerInfoByWorkerId(string workerId)
        {
            Worker w = new Worker();
            w = workerRepository.GetSingle(a => a.WorkerId == workerId);
            //解密身份证号码
            var sourceStr = w.CardId.Contains("·") ? encrypt.Decryption(w.CardId) : w.CardId;
            w.CardId = sourceStr;
            //解密联系方式
            var sourceTelStr = w.WorkerTel.Contains("·") ? encrypt.Decryption(w.WorkerTel) : w.WorkerTel;
            w.WorkerTel = sourceTelStr;
            //性别类型
            var sexType = sexTypeRepository.GetSingle(a => a.sexId == w.WorkerSex);
            w.WorkerSexName = string.IsNullOrEmpty(sexType.sexName) ? "" : sexType.sexName;
            //教育程度
            var eduction = educationRepository.GetSingle(a => a.education_no == w.WorkerEducation);
            w.EducationName = string.IsNullOrEmpty(eduction.education_name) ? "" : eduction.education_name;
            //民族类型
            var nation = nationRepository.GetSingle(a => a.nation_no == w.WorkerNation);
            w.NationName = string.IsNullOrEmpty(nation.nation_name) ? "" : nation.nation_name;
            //部门
            var dept = deptRepository.GetSingle(a => a.dept_no == w.WorkerClub);
            w.ClubName = string.IsNullOrEmpty(dept.dept_name) ? "" : dept.dept_name;
            //职位
            var position = positionRepository.GetSingle(a => a.position_no == w.WorkerPosition);
            w.PositionName = string.IsNullOrEmpty(position.position_name) ? "" : position.position_name;
            return w;
        }
        #endregion

        #region 根据登录名称、密码查询员工信息
        /// <summary>
        /// 根据登录名称、密码查询员工信息
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public Worker SelectWorkerInfoByWorkerIdAndWorkerPwd(Worker worker)
        {
            Worker w = new Worker();
            w = workerRepository.GetSingle(a => a.WorkerId == worker.WorkerId);
            if (w == null)
            {
                w = null;
                return w;
            }

            var frontEncryed = encrypt.Encryption(w.WorkerPwd, EncryptionLevel.Enhanced);
            var backEncryed = encrypt.Encryption(worker.WorkerPwd, EncryptionLevel.Enhanced);

            if (!encrypt.Compare(frontEncryed, backEncryed))
            {
                w = null;
                return w;
            }
            w.WorkerPwd = "";
            //性别类型
            var sexType = sexTypeRepository.GetSingle(a => a.sexId == w.WorkerSex);
            w.WorkerSexName = string.IsNullOrEmpty(sexType.sexName) ? "" : sexType.sexName;
            //教育程度
            var eduction = educationRepository.GetSingle(a => a.education_no == w.WorkerEducation);
            w.EducationName = string.IsNullOrEmpty(eduction.education_name) ? "" : eduction.education_name;
            //民族类型
            var nation = nationRepository.GetSingle(a => a.nation_no == w.WorkerNation);
            w.NationName = string.IsNullOrEmpty(nation.nation_name) ? "" : nation.nation_name;
            //部门
            var dept = deptRepository.GetSingle(a => a.dept_no == w.WorkerClub);
            w.ClubName = string.IsNullOrEmpty(dept.dept_name) ? "" : dept.dept_name;
            //职位
            var position = positionRepository.GetSingle(a => a.position_no == w.WorkerPosition);
            w.PositionName = string.IsNullOrEmpty(position.position_name) ? "" : position.position_name;

            //附带Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, w.WorkerId)
                }),
                Expires = DateTime.Now.AddMinutes(20), // 设置Token过期时间
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = configuration["Jwt:Audience"],
                Issuer = configuration["Jwt:Issuer"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            w.user_token = tokenHandler.WriteToken(token);

            return w;
        }
        #endregion

        /// <summary>
        /// 根据员工编号和密码修改密码
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public bool UpdWorkerPwdByWorkNo(Worker worker)
        {
            string NewPwd = encrypt.Decryption(worker.WorkerPwd);
            return workerRepository.Update(a => new Worker()
            {
                WorkerPwd = NewPwd,
                datachg_usr = worker.datachg_usr
            }, a => a.WorkerId == worker.WorkerId);
        }

    }
}
