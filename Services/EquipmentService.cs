using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ToolRenter.Data;
using ToolRenter.Models.Equipment;
using ToolRenter.Services.Engines.Equipment;

namespace ToolRenter.Services
{
    public class EquipmentService
    {
        private readonly Guid _userId;

        public EquipmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEquipment(EquipmentCreate model)
        {
            //Like mapper in Core
            var entity = new Equipment()
            {
                OwnerId = _userId,
                EquipmentName = model.EquipmentName,
                EquipmentTypeId = model.EquipmentTypeId,
                EquipmentDescription = model.EquipmentDescription,
                EquipmentRate = model.EquipmentRate
            };

            //Upload File Transfer to engine output a string
            var engine = new PhotoUploadEngine();
            var uri = engine.Upload(model.PhotoUpload);
            entity.PhotoUpload = uri;

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Equipments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EquipmentListItem> GetEquipment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Equipments.Where(e => e.OwnerId == _userId)
                    .Select(e => new EquipmentListItem
                    {
                        EquipmentId = e.EquipmentId,
                        EquipmentName = e.EquipmentName,
                        EquipmentDescription = e.EquipmentDescription,
                        EquipmentRate = e.EquipmentRate
                    });

                return query.ToArray();
            }
        }

        public EquipmentDetail GetEquipmentById(int equipmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Equipments.Single(e => e.EquipmentId == equipmentId && e.OwnerId == _userId);
                return new EquipmentDetail
                {
                    EquipmentId = entity.EquipmentId,
                    EquipmentName = entity.EquipmentName,
                    EquipmentDescription = entity.EquipmentDescription,
                    EquipmentRate = entity.EquipmentRate
                };
            }
        }

        public bool UpdateEquipment(EquipmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Equipments.Single(e => e.EquipmentId == model.EquipmentId && e.OwnerId == _userId);

                entity.EquipmentId = model.EquipmentId;
                entity.EquipmentName = model.EquipmentName;
                entity.EquipmentDescription = model.EquipmentDescription;
                entity.EquipmentRate = model.EquipmentRate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEquipment(int equipmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Equipments.Single(e => e.EquipmentId == equipmentId && e.OwnerId == _userId);
                ctx.Equipments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
