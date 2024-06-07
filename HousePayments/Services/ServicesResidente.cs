using HousePayments.Dto.ResidentesDto;
using HousePayments.Interfaces;
using HousePayments.Models;
using Microsoft.AspNetCore.DataProtection;

namespace HousePayments.Services
{
    public class ServicesResidente : IServicesResidentes
    {
        private IRepositoryResidente<Residente> _residenteRepo;
        private readonly IDataProtectionProvider _dataProtectionProvider;

        public ServicesResidente(
            IRepositoryResidente<Residente> residenteRepo,
            IDataProtectionProvider dataProtectionProvider
            ) { 
            _residenteRepo = residenteRepo;
            _dataProtectionProvider = dataProtectionProvider;
        }

        public async Task<ResidenteDto> CreateResidente(CreateResidenteDto createResidenteDto)
        {
            try
            {
                var protector = _dataProtectionProvider.CreateProtector("ProtectPass");
                var protectedPass = protector.Protect(createResidenteDto.Password);

                var residente = new Residente
                {
                    Nombre = createResidenteDto.Nombre,
                    Email = createResidenteDto.Email,
                    Password = protectedPass,
                    Telefono = createResidenteDto.Telefono
                };

                await _residenteRepo.CreateResidente(residente);
                await _residenteRepo.Save();

                var residenteDto = new ResidenteDto
                {
                    ResidenteId = residente.ResidenteId,
                    Email = residente.Email,
                    Nombre = residente.Nombre,
                    Telefono = residente.Telefono,
                    Estado = residente.Estado
                };

                return residenteDto;
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public async Task<ResidenteDto> DisableResidente(int id)
        {
            try
            {
                var estadoRes = new Residente { ResidenteId = id, Estado = false };
                _residenteRepo.DisableResidente(estadoRes);
                await _residenteRepo.Save();

                var resDto = new ResidenteDto
                {
                     ResidenteId= id,
                };

                return resDto;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<ResidenteDto>> GetResidentes()
        {
            var residentes = await _residenteRepo.GetResidentes();

            return residentes.Select(r => new ResidenteDto
            {
                ResidenteId = r.ResidenteId,
                Nombre = r.Nombre,
                Email = r.Email,
                Telefono = r.Telefono,
                Estado = r.Estado,
            });
        }

        public async Task<ResidenteDto> GetResidente(int id)
        {
            var residente = await _residenteRepo.GetResidente(id);
            if(residente != null)
            {
                var resDto = new ResidenteDto
                {
                    ResidenteId = residente.ResidenteId,
                    Nombre= residente.Nombre,
                    Email = residente.Email,
                    Telefono= residente.Telefono,
                    Estado  = residente.Estado,
                };

                return resDto;
            }
            return null;
        }

        public async Task<ResidenteDto> UpdateResidente(int id, UpdateResidenteDto updateResidenteDto)
        {
            try
            {
                Console.WriteLine(id);
                var res = await _residenteRepo.GetResidente(id);


                if (res != null)
                {
                    res.Nombre = updateResidenteDto.Nombre ?? res.Nombre;
                    res.Email = updateResidenteDto.Email ?? res.Email;
                    res.Telefono = updateResidenteDto.Telefono ?? res.Telefono;
                    res.Estado = updateResidenteDto.Estado ?? res.Estado;

                    _residenteRepo.UpdateResidente(res);
                    await _residenteRepo.Save();

                    var resDto = new ResidenteDto
                    {
                        ResidenteId = id,
                        Nombre = res.Nombre,
                        Email = res.Email,
                        Telefono = res.Telefono,
                        Estado = res.Estado,
                    };

                    return resDto;
                }

                return null;
            }catch(Exception e) {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
