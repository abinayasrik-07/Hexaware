
using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Repository;

namespace CarConnect.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin GetAdminById(int adminId)
        {
            var admin = _adminRepository.GetAdminById(adminId);
            if (admin == null)
            {
                throw new AdminNotFoundException($"Admin with ID {adminId} not found.");
            }
            return admin;
        }

        public Admin GetAdminByUsername(string username)
        {
            var admin = _adminRepository.GetAdminByUsername(username);
            if (admin == null)
            {
                throw new AdminNotFoundException($"Admin with username {username} not found.");
            }
            return admin;
        }

        public void RegisterAdmin(Admin adminData)
        {
            _adminRepository.RegisterAdmin(adminData);
        }

        public void UpdateAdmin(Admin adminData)
        {
            _adminRepository.UpdateAdmin(adminData);
        }

        public void DeleteAdmin(int adminId)
        {
            _adminRepository.DeleteAdmin(adminId);
        }
    }
}
