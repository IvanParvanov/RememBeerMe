using System.Collections.Generic;

using RememBeer.Business.Logic.Admin.UserDetails;
using RememBeer.Models.Contracts;

namespace RememBeer.Tests.Business.Mocks
{
    public class MockedUserDetailsViewModel : UserDetailsViewModel
    {
        public override IEnumerable<IBeerReview> Reviews { get; set; }

        public override IApplicationUser User { get; set; }
    }
}
