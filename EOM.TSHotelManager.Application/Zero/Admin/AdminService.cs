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
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EOM.TSHotelManager.Application
{
    /// <summary>
    /// 管理员数据访问层
    /// </summary>
    public class AdminService : IAdminService
    {
        /// <summary>
        /// 管理员
        /// </summary>
        private readonly GenericRepository<Admin> adminRepository;

        /// <summary>
        /// 管理员类型
        /// </summary>
        private readonly GenericRepository<AdminType> adminTypeRepository;

        /// <summary>
        /// 加密
        /// </summary>
        private readonly jvncorelib.EncryptorLib.EncryptLib encrypt;

        /// <summary>
        /// JWT加密
        /// </summary>
        private readonly IJwtConfigFactory _jwtConfigFactory;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="adminRepository"></param>
        /// <param name="adminTypeRepository"></param>
        /// <param name="encrypt"></param>
        /// <param name="_jwtConfigFactory"></param>
        public AdminService(GenericRepository<Admin> adminRepository, GenericRepository<AdminType> adminTypeRepository, EncryptLib encrypt, IJwtConfigFactory _jwtConfigFactory)
        {
            this.adminRepository = adminRepository;
            this.adminTypeRepository = adminTypeRepository;
            this.encrypt = encrypt;
            this._jwtConfigFactory = _jwtConfigFactory;
        }

        #region 根据超管密码查询员工类型和权限
        /// <summary>
        /// 根据超管密码查询员工类型和权限
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public Admin SelectManagerByPass(Admin admin)
        {
            if (admin == null)
            {
                throw new ArgumentNullException(nameof(admin));
            }

            var existingAdmin = adminRepository.GetSingle(a => a.AdminAccount == admin.AdminAccount);

            if (existingAdmin == null)
            {
                return null;
            }

            string existingAdminPassword = existingAdmin.AdminPassword;

            if (existingAdminPassword.Contains("·"))
            {
                if (!encrypt.Compare(admin.AdminPassword, existingAdminPassword))
                {
                    return null;
                }
            }
            else if (!admin.AdminPassword.Equals(existingAdminPassword))
            {
                return null;
            }

            if (admin.DeleteMk == 1)
            {
                return null;
            }

            existingAdmin.AdminPassword = string.Empty;

            var jwtConfig = _jwtConfigFactory.GetJwtConfig();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, admin.AdminAccount)
                }),
                Expires = DateTime.Now.AddMinutes(jwtConfig.ExpiryMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = jwtConfig.Audience,
                Issuer = jwtConfig.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            existingAdmin.user_token = tokenHandler.WriteToken(token);

            return existingAdmin;
        }
        #endregion

        #region 根据超管账号查询对应的密码
        /// <summary>
        /// 根据超管账号查询对应的密码
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public Admin SelectAdminPwdByAccount(string account)
        {
            Admin admin = new Admin();
            admin = adminRepository.GetSingle(a => a.AdminAccount == account);
            return admin;
        }
        #endregion

        /// <summary>
        /// 获取所有管理员列表
        /// </summary>
        /// <returns></returns>
        public List<Admin> GetAllAdminList()
        {
            var listAdmins = adminRepository.GetList();
            var listAdminType = adminTypeRepository.GetList(a => a.delete_mk != 1);
            listAdmins.ForEach(admins =>
            {
                var isAdminType = admins.IsAdmin == 1 ? "是" : "否";
                admins.IsAdminNm = isAdminType;

                var adminType = listAdminType.FirstOrDefault(a => a.type_id.Equals(admins.AdminType));
                admins.TypeName = adminType == null ? "" : adminType.type_name;

                var adminDelete = admins.DeleteMk == 1 ? "是" : "否";
                admins.DeleteNm = adminDelete;

            });

            return listAdmins;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool UpdateNewPwdByOldPwd(Admin admin)
        {
            admin.AdminPassword = encrypt.Encryption(admin.AdminPassword, EncryptionLevel.Enhanced);
            return adminRepository.Update(a => new Admin()
            {
                AdminPassword = admin.AdminPassword
            }, a => a.AdminAccount == admin.AdminAccount);
        }

        /// <summary>
        /// 获取管理员列表(已启用)
        /// </summary>
        /// <returns></returns>
        public List<Admin> GetAllAdmin()
        {
            var listAdmin = adminRepository.GetList(a => a.DeleteMk != 1);
            var listAdminType = adminTypeRepository.GetList(a => a.delete_mk != 1);
            listAdmin.ForEach(admin =>
            {
                var isAdminType = admin.IsAdmin == 1 ? "是" : "否";
                admin.IsAdminNm = isAdminType;

                var adminType = listAdminType.FirstOrDefault(a => a.type_id.Equals(admin.AdminType));
                admin.TypeName = adminType == null ? "" : adminType.type_name;
            });
            return listAdmin;
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool AddAdmin(Admin admin)
        {
            admin.AdminPassword = encrypt.Encryption(admin.AdminPassword, EncryptionLevel.Enhanced);
            bool result = adminRepository.Insert(admin);
            return result;
        }

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public Admin GetAdminInfoByAdminAccount(Admin admin)
        {
            var adminInfo = adminRepository.GetSingle(a => a.AdminAccount.Equals(admin.AdminAccount));
            if (adminInfo != null)
            {
                var adminType = adminTypeRepository.GetSingle(a => a.type_id.Equals(adminInfo.AdminType));
                adminInfo.TypeName = adminType.type_name;
            }
            return adminInfo;
        }

        /// <summary>
        /// 获取所有管理员类型
        /// </summary>
        /// <returns></returns>
        public List<AdminType> GetAllAdminTypes()
        {
            var listAdminTypes = adminTypeRepository.GetList(a => a.delete_mk != 1);
            return listAdminTypes;
        }

        /// <summary>
        /// 更新管理员账户
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public bool UpdAccount(Admin admins)
        {
            admins.DeleteMk = admins.DeleteMk == 0 ? 1 : 0;
            return adminRepository.Update(a => new Admin()
            {
                DeleteMk = admins.DeleteMk
            }, a => a.Id == admins.Id);
        }


    }
}
