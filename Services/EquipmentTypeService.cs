using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolRenter.Data;
using ToolRenter.Models.EquipmentType;

namespace ToolRenter.Services
{
    public class EquipmentTypeService
    {
        //Get All Equipment Types
        public IEnumerable<EquipmentTypeListItem> GetEquipmentType()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.EquipmentTypes
                    .Select(e => new EquipmentTypeListItem
                    {
                        EquipmentTypeId = e.EquipmentTypeId,
                        EquipmentTypeString = e.EquipmentTypeString
                    });

                return query.ToArray();
            }
        }
        //Get Equipment Type by Id
        public EquipmentTypeDetail GetEquipmentTypeById(int equipmentTypeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.EquipmentTypes.Single(e => e.EquipmentTypeId == equipmentTypeId);
                return new EquipmentTypeDetail
                {
                    EquipmentTypeId = entity.EquipmentTypeId,
                    EquipmentTypeString = entity.EquipmentTypeString
                };
            }
        }
        //Create Equipment Type
        public bool CreateEquipmentType(EquipmentTypeCreate model)
        {
            var entity = new EquipmentType()
            {
                EquipmentTypeString = model.EquipmentTypeString
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.EquipmentTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Edit Equipment Type
        public bool UpdateEquipment(EquipmentTypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.EquipmentTypes.Single(e => e.EquipmentTypeId == model.EquipmentTypeId);

                entity.EquipmentTypeId = model.EquipmentTypeId;
                entity.EquipmentTypeString = model.EquipmentTypeString;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Equipment Type
        public bool DeleteEquipmentType(int equipmentTypeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.EquipmentTypes.Single(e => e.EquipmentTypeId == equipmentTypeId);
                ctx.EquipmentTypes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
