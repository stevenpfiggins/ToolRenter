using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolRenter.Data;
using ToolRenter.Models.Request;

namespace ToolRenter.Services
{
    public class RequestService
    {
        private readonly Guid _userId;

        public RequestService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRequest(RequestCreate model)
        {
            var entity =
                new Request()
                {
                    OwnerId = _userId,
                    EquipmentTypeRequested = model.EquipmentTypeRequested,
                    BeginningDateRequested = model.BeginningDateRequested,
                    EndingDateRequested = model.EndingDateRequested
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Requests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RequestListItem> GetRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Requests
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RequestListItem
                                {
                                    RequestId = e.RequestId,
                                    EquipmentTypeRequested = e.EquipmentTypeRequested,
                                    BeginningDateRequested = e.BeginningDateRequested,
                                    EndingDateRequested = e.EndingDateRequested
                                }
                        );

                return query.ToArray();
            }
        }

        public RequestDetail GetRequestById(int requestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Requests
                        .Single(e => e.RequestId == requestId && e.OwnerId == _userId);
                    return
                        new RequestDetail
                        {
                            RequestId = entity.RequestId,
                            EquipmentTypeRequested = entity.EquipmentTypeRequested,
                            BeginningDateRequested = entity.BeginningDateRequested,
                            EndingDateRequested = entity.EndingDateRequested
                        };
            }
        }

        public bool UpdateRequest(RequestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Requests
                        .Single(e => e.RequestId == model.RequestId && e.OwnerId == _userId);

                entity.EquipmentTypeRequested = model.EquipmentTypeRequested;
                entity.BeginningDateRequested = model.BeginningDateRequested;
                entity.EndingDateRequested = model.EndingDateRequested;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRequest(int requestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Requests
                        .Single(e => e.RequestId == requestId && e.OwnerId == _userId);

                ctx.Requests.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
