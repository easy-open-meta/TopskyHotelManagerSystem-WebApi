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
using EOM.TSHotelManager.Common.Core;
using EOM.TSHotelManager.EntityFramework;
using EOM.TSHotelManager.Shared;
using jvncorelib.EncryptorLib;
using jvncorelib.EntityLib;
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
    /// <remarks>
    /// 构造函数
    /// </remarks>
    /// <param name="workerRepository"></param>
    /// <param name="sexTypeRepository"></param>
    /// <param name="educationRepository"></param>
    /// <param name="nationRepository"></param>
    /// <param name="deptRepository"></param>
    /// <param name="positionRepository"></param>
    /// <param name="encrypt"></param>
    /// <param name="jwtConfigFactory"></param>
    public class WorkerService(GenericRepository<Worker> workerRepository, GenericRepository<SexType> sexTypeRepository, GenericRepository<Education> educationRepository, GenericRepository<Nation> nationRepository, GenericRepository<Dept> deptRepository, GenericRepository<Position> positionRepository, EncryptLib encrypt, IJwtConfigFactory jwtConfigFactory) : IWorkerService
    {
        /// <summary>
        /// 员工信息
        /// </summary>
        private readonly GenericRepository<Worker> workerRepository = workerRepository;

        /// <summary>
        /// 性别类型
        /// </summary>
        private readonly GenericRepository<SexType> sexTypeRepository = sexTypeRepository;

        /// <summary>
        /// 学历类型
        /// </summary>
        private readonly GenericRepository<Education> educationRepository = educationRepository;

        /// <summary>
        /// 民族类型
        /// </summary>
        private readonly GenericRepository<Nation> nationRepository = nationRepository;

        /// <summary>
        /// 部门
        /// </summary>
        private readonly GenericRepository<Dept> deptRepository = deptRepository;

        /// <summary>
        /// 职务
        /// </summary>
        private readonly GenericRepository<Position> positionRepository = positionRepository;

        /// <summary>
        /// 加密
        /// </summary>
        private readonly jvncorelib.EncryptorLib.EncryptLib encrypt = encrypt;

        /// <summary>
        /// JWT加密
        /// </summary>
        private readonly IJwtConfigFactory _jwtConfigFactory = jwtConfigFactory;

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
            if (!worker.WorkerTel.IsNullOrEmpty())
            {
                sourceTelStr = encrypt.Encryption(worker.WorkerTel, EncryptionLevel.Enhanced);
            }
            //加密身份证
            var sourceIdStr = string.Empty;
            if (!worker.CardId.IsNullOrEmpty())
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
                source.WorkerSexName = sexType.sexName.IsNullOrEmpty() ? "" : sexType.sexName;
                //教育程度
                var eduction = educations.FirstOrDefault(a => a.education_no == source.WorkerEducation);
                source.EducationName = eduction.education_name.IsNullOrEmpty() ? "" : eduction.education_name;
                //民族类型
                var nation = nations.FirstOrDefault(a => a.nation_no == source.WorkerNation);
                source.NationName = nation.nation_name.IsNullOrEmpty() ? "" : nation.nation_name;
                //部门
                var dept = depts.FirstOrDefault(a => a.dept_no == source.WorkerClub);
                source.ClubName = dept.dept_name.IsNullOrEmpty() ? "" : dept.dept_name;
                //职位
                var position = positions.FirstOrDefault(a => a.position_no == source.WorkerPosition);
                source.PositionName = position.position_name.IsNullOrEmpty() ? "" : position.position_name;
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
            w.WorkerSexName = sexType.sexName.IsNullOrEmpty() ? "" : sexType.sexName;
            //教育程度
            var eduction = educationRepository.GetSingle(a => a.education_no == w.WorkerEducation);
            w.EducationName = eduction.education_name.IsNullOrEmpty() ? "" : eduction.education_name;
            //民族类型
            var nation = nationRepository.GetSingle(a => a.nation_no == w.WorkerNation);
            w.NationName = nation.nation_name.IsNullOrEmpty() ? "" : nation.nation_name;
            //部门
            var dept = deptRepository.GetSingle(a => a.dept_no == w.WorkerClub);
            w.ClubName = dept.dept_name.IsNullOrEmpty() ? "" : dept.dept_name;
            //职位
            var position = positionRepository.GetSingle(a => a.position_no == w.WorkerPosition);
            w.PositionName = position.position_name.IsNullOrEmpty() ? "" : position.position_name;
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
            w.WorkerSexName = sexType.sexName.IsNullOrEmpty() ? "" : sexType.sexName;
            //教育程度
            var eduction = educationRepository.GetSingle(a => a.education_no == w.WorkerEducation);
            w.EducationName = eduction.education_name.IsNullOrEmpty() ? "" : eduction.education_name;
            //民族类型
            var nation = nationRepository.GetSingle(a => a.nation_no == w.WorkerNation);
            w.NationName = nation.nation_name.IsNullOrEmpty() ? "" : nation.nation_name;
            //部门
            var dept = deptRepository.GetSingle(a => a.dept_no == w.WorkerClub);
            w.ClubName = dept.dept_name.IsNullOrEmpty() ? "" : dept.dept_name;
            //职位
            var position = positionRepository.GetSingle(a => a.position_no == w.WorkerPosition);
            w.PositionName = position.position_name.IsNullOrEmpty() ? "" : position.position_name;

            //附带Token
            var jwtConfig = _jwtConfigFactory.GetJwtConfig();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, w.WorkerId)
                }),
                Expires = DateTime.Now.AddMinutes(jwtConfig.ExpiryMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = jwtConfig.Audience,
                Issuer = jwtConfig.Issuer
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
