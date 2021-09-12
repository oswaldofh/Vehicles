using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicles.API.Data.Entities;
using Vehicles.API.Helpers;
using Vehicles.Common.Enums;

namespace Vehicles.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckVehiclesTypeAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckRolesAsycn();
            await CheckUserAsycn("1010", "Pedro", "PicaPiedra", "pedro@yopmail.com", "312 234 3456", "cll 34 # 50-34", UserType.User);
            await CheckUserAsycn("2020", "Juan", "Valdez", "juan@yopmail.com", "312 234 3456", "cll 34 # 50-34", UserType.Admin);
            await CheckUserAsycn("3030", "Raul", "Santy", "raul@yopmail.com", "312 234 3456", "cll 34 # 50-34", UserType.User);
            await CheckUserAsycn("2020", "Juliana", "Franco", "Juliana@yopmail.com", "312 234 3456", "cll 34 # 50-34", UserType.Admin);


        }

        private async Task CheckUserAsycn(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if(user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cedula"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            
        }

        private Task CheckUserAsycn()
        {
            throw new NotImplementedException();
        }

        private async Task CheckRolesAsycn()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio Aceite" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Alineacion" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio Caja" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Filtro de aire" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Guayas" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Cambio llanta delantera" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "Cedula" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Tarjeta de Identidad" });
                _context.DocumentTypes.Add(new DocumentType { Description = "NIT" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {
                _context.Brands.Add(new Brand { Description = "Ducaty" });
                _context.Brands.Add(new Brand { Description = "AKT" });
                _context.Brands.Add(new Brand { Description = "Mazda" });
                _context.Brands.Add(new Brand { Description = "Yamaha" });
                _context.Brands.Add(new Brand { Description = "TVS" });
                _context.Brands.Add(new Brand { Description = "Chevrolet" });
                _context.Brands.Add(new Brand { Description = "Honda" });
                _context.Brands.Add(new Brand { Description = "Victoria" });
                _context.Brands.Add(new Brand { Description = "KTM" });
                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckVehiclesTypeAsync()
        {
           if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Description = "Carro" });
                _context.VehicleTypes.Add(new VehicleType { Description = "Moto" });
                await _context.SaveChangesAsync();

            }
        }
    }
}
