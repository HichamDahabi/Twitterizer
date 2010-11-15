﻿namespace Twitterizer2.TestCases
{
    using Twitterizer;
    using NUnit.Framework;
    
    [TestFixture()]
    public class PagingTests
    {
        [Test]
        [Category("Read-Only")]
        [Category("REST")]
        [Category("Paging")]
        public static void Mentions()
        {
            OAuthTokens tokens = Configuration.GetTokens();

            TwitterResponse<TwitterStatusCollection> response = TwitterTimeline.Mentions(tokens);

            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);

            decimal firstId = response.ResponseObject[0].Id;

            response = response.ResponseObject.NextPage();
            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);
            Assert.AreNotEqual(response.ResponseObject[0].Id, firstId);
        }

        [Test]
        [Category("Read-Only")]
        [Category("REST")]
        [Category("Paging")]
        public static void UserTimeline()
        {
            OAuthTokens tokens = Configuration.GetTokens();

            TwitterResponse<TwitterStatusCollection> response = TwitterTimeline.UserTimeline(tokens);

            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);

            decimal firstId = response.ResponseObject[0].Id;

            response = response.ResponseObject.NextPage();
            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);
            Assert.AreNotEqual(response.ResponseObject[0].Id, firstId);
        }

        [Test]
        [Category("Read-Only")]
        [Category("REST")]
        [Category("Paging")]
        public static void Friends()
        {
            OAuthTokens tokens = Configuration.GetTokens();

            TwitterResponse<TwitterStatusCollection> response = TwitterTimeline.FriendTimeline(tokens, new TimelineOptions() { Count = 2 });

            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);

            decimal firstId = response.ResponseObject[0].Id;

            response = response.ResponseObject.NextPage();
            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);
            Assert.AreNotEqual(response.ResponseObject[0].Id, firstId);
        }

        [Test]
        [Category("Read-Only")]
        [Category("REST")]
        [Category("Paging")]
        public static void Home()
        {
            OAuthTokens tokens = Configuration.GetTokens();

            TwitterResponse<TwitterStatusCollection> response = TwitterTimeline.HomeTimeline(tokens);

            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);

            decimal firstId = response.ResponseObject[0].Id;

            response = response.ResponseObject.NextPage();
            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);
            Assert.AreNotEqual(response.ResponseObject[0].Id, firstId);
        }

        [Test]
        [Category("Read-Only")]
        [Category("REST")]
        [Category("Paging")]
        public static void Followers()
        {
            OAuthTokens tokens = Configuration.GetTokens();

            TwitterResponse<TwitterUserCollection> response = TwitterFriendship.Followers(tokens, new FollowersOptions() { ScreenName = "twitterapi" });

            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);

            decimal firstId = response.ResponseObject[0].Id;

            response = response.ResponseObject.NextPage();
            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);
            Assert.AreNotEqual(response.ResponseObject[0].Id, firstId);
        }

        [Test]
        [Category("Read-Only")]
        [Category("REST")]
        [Category("Paging")]
        public static void FollowersIds()
        {
            OAuthTokens tokens = Configuration.GetTokens();

            TwitterResponse<UserIdCollection> response = TwitterFriendship.FollowersIds(tokens, new UsersIdsOptions()
            {
                ScreenName = "twitterapi"
            });

            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);

            decimal firstId = response.ResponseObject[0];

            response = response.ResponseObject.NextPage();
            Assert.IsNotNull(response);
            Assert.That(response.Result == RequestResult.Success);
            Assert.IsNotNull(response.ResponseObject);
            Assert.That(response.ResponseObject.Count > 0);
            Assert.AreNotEqual(response.ResponseObject[0], firstId);
        }
    }
}
