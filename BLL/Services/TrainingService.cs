using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTC.BLL.Services.Interfaces;
using VTC.Common.ViewModels;
using VTC.DataAccess.Data;
using VTC.DataAccess.Entities;

namespace VTC.BLL.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly VTCContext _context;

        public TrainingService(VTCContext context) {
            _context = context;
        }

        public async Task Add(TrainingViewModel model)
        {
            Training training = new Training()
            {
                CreatedDate = DateTime.Now,
                Description = model.Description,
                IsDeleted = false,
                Name = model.Name,
                Status = model.Status,
                Type = model.Type,
            };

            _context.Trainings.Add(training);
            _context.SaveChanges();
        }

        public async Task Edit(TrainingViewModel model)
        {
            var training = _context.Trainings.Where(a => a.Id == model.Id).FirstOrDefault();

            training.Name = model.Name;
            training.Description = model.Description;
            training.Status = model.Status;
            training.Type = model.Type;
            
            _context.SaveChanges();
        }

        public  List<TrainingViewModel> GetAll(int statusId)
        {
            var trainings =  _context.Trainings.Where(a => !a.IsDeleted && (int)a.Status == statusId)
                .Select(a => new TrainingViewModel { 
                    Description = a.Description,
                    Id = a.Id,
                    Name = a.Name,
                    Status = a.Status,
                    Type = a.Type,
                }).ToList();

            return trainings;
        }

        public async Task<TrainingViewModel> GetById(int id)
        {
            var training = _context.Trainings.Where(a => a.Id == id).Select(a => new TrainingViewModel { 
                Type = a.Type,
                Status = a.Status,
                Name = a.Name,
                Id = a.Id,
                Description = a.Description,
            }).FirstOrDefault();

            return training;
        }

        public async Task Remove(int id)
        {
            var training = _context.Trainings.Where(a => a.Id == id).FirstOrDefault();
            training.IsDeleted = true;
            _context.SaveChanges();

        }
    }
}
