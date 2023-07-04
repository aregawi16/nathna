
using NatnaAgencyDigitalSystem.Api.Services;
using NatnaAgencyDigitalSystem.Api;
using NatnaAgencyDigitalSystem.Api.Models.Setting;

namespace NatnaAgencyDigitalSystem.Service
{
   
        public class CommonJobService : ICommonJobService
        {
            private readonly IUnitOfWork _unitOfWork;
            public CommonJobService(IUnitOfWork unitOfWork)
            {
                this._unitOfWork = unitOfWork;
            }


            public async Task<CommonJob> CreateCommonJob(CommonJob newCommonJob)
            {
                await _unitOfWork.CommonJobs
                    .AddAsync(newCommonJob);
                await _unitOfWork.CommitAsync();

                return newCommonJob;
            }

            public async Task DeleteCommonJob(CommonJob CommonJob)
            {
                _unitOfWork.CommonJobs.Remove(CommonJob);

                await _unitOfWork.CommitAsync();
            }

            public async Task<IEnumerable<CommonJob>> GetAllCommonJobs()
            {
                return await _unitOfWork.CommonJobs.GetAllAsync();
            }

            public async Task<CommonJob> GetCommonJobById(int id)
            {
                return await _unitOfWork.CommonJobs.GetByIdAsync(id);
            }

            public async Task UpdateCommonJob(CommonJob CommonJobToBeUpdated, CommonJob CommonJob)
            {
                //  CommonJobToBeUpdated. = CommonJob.Name;

                await _unitOfWork.CommitAsync();
            }
        }

    
}
