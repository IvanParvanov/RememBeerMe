using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Repositories.Enums;
using RememBeer.Models;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.BeerReviewServiceTests
{
    [TestFixture]
    public class GetAll_Should : TestClassBase
    {
        //[Test]
        //public void Call_RepositoryGetAllMethodWithCorrectParams_WhenNotPaginated()
        //{
        //    var expectedUserId = this.Fixture.Create<string>();
        //    var mockedRepository = new Mock<IRepository<BeerReview>>();
        //    var reviewService = new BeerReviewService(mockedRepository.Object);

        //    Expression<Func<BeerReview, bool>> b = ( x => x.IsDeleted == false && x.ApplicationUserId == expectedUserId );
        //    var expectedFilter = It.Is<Expression<Func<BeerReview, bool>>>(expr =>
        //                                                                       expr.ToString()
        //                                                                       .Contains("IsDeleted == False"));

        //    var expectedSort =
        //        It.Is<Expression<Func<BeerReview, DateTime>>>(expr => expr.ToString().Contains("CreatedAt"));

        //    reviewService.GetReviewsForUser(expectedUserId);

        //    mockedRepository.Verify(r => r.GetAll(
        //                                          It.IsAny<Expression<Func<BeerReview, bool>>>(),
        //                                          //expectedFilter,
        //                                          //It.IsAny<Expression<Func<BeerReview, DateTime>>>(),
        //                                          expectedSort,
        //                                          SortOrder.Descending
        //                                         ));
        //}
    }
}
