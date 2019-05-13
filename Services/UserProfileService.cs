using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolRenter.Data;
using ToolRenter.Models.UserProfile;

namespace ToolRenter.Services
{
    public class UserProfileService
    {
        private readonly Guid _userId;

        public UserProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUserProfile(UserProfileCreate model)
        {
            var entity =
                new UserProfile()
                {
                    OwnerId = _userId,
                    UserName = model.UserName,
                    Email = model.Email,
                    ZipCode = model.ZipCode
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserProfiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserProfileListItem> GetUserProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .UserProfiles
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new UserProfileListItem
                                {
                                    UserProfileId = e.UserProfileId,
                                    UserName = e.UserName,
                                    Email = e.Email,
                                    ZipCode = e.ZipCode
                                }
                        );

                return query.ToArray();
            }
        }

        public UserProfileDetail GetUserProfilesById(int profileId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserProfiles
                        .Single(e => e.UserProfileId == profileId && e.OwnerId == _userId);
                return
                    new UserProfileDetail
                    {
                        UserProfileId = entity.UserProfileId,
                        UserName = entity.UserName,
                        Email = entity.Email,
                        ZipCode = entity.ZipCode
                    };
            }
        }

        public bool UpdateUserProfile(UserProfileEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserProfiles
                        .Single(e => e.UserProfileId == model.UserProfileId && e.OwnerId == _userId);

                entity.UserName = model.UserName;
                entity.Email = model.Email;
                entity.ZipCode = model.ZipCode;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUserProfile(int profileId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .UserProfiles
                        .Single(e => e.UserProfileId == profileId && e.OwnerId == _userId);

                ctx.UserProfiles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
