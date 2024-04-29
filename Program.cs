
using Reddit;
using Reddit.Controllers;
using Reddit.Inputs;

    //  Create a new Reddit.NET instance 
    //  RedditClient.RedditClient([string appId = null], [string refreshToken = null], [string appSecret = null], [string accessToken = null], [string userAgent = null])
    var reddit = new RedditClient("08od_DYkpV_IJvC26XrxjA", 
                                null,
                                "4zKq1RJSikxk2flmR4Hpzos2o2TPgA",
                                "eyJhbGciOiJSUzI1NiIsImtpZCI6IlNIQTI1NjpzS3dsMnlsV0VtMjVmcXhwTU40cWY4MXE2OWFFdWFyMnpLMUdhVGxjdWNZIiwidHlwIjoiSldUIn0.eyJzdWIiOiJ1c2VyIiwiZXhwIjoxNzE0NDc5NjM3LjQ1NzI3MSwiaWF0IjoxNzE0MzkzMjM3LjQ1NzI3LCJqdGkiOiI0dWhxODFDQUZDSkpJSE9qQlc5MmR4RFdrS1JKeUEiLCJjaWQiOiIwOG9kX0RZa3BWX0lKdkMyNlhyeGpBIiwibGlkIjoidDJfdDhqem8ybGE5IiwiYWlkIjoidDJfdDhqem8ybGE5IiwibGNhIjoxNzA2NzI1NDM2MTcxLCJzY3AiOiJlSnlLVnRKU2lnVUVBQURfX3dOekFTYyIsImZsbyI6OX0.RfVCqgDSvR5AlkXRmNuncIjW29Lyegngywpv4dzr83SSvzm6LByL4JNd93QvYnzwGM2H4RiWcBbmmQYMiJI59pJQHcKnwMQiBrHtbjgVt81tRrOMIAV7DIaM6ZVDaByGZMi3oHzrnFTH8S9jhtjLjS_9zFZw7zRIuKJ1ddx5cwQpDjMi-Eg5b2pFSVNXLzuS8BYA2B7AHDHJukEiZb0PSJbQS6b84zNyR4J_TBM64Z8edO34zLS4yR7KoGuYEBXSInjeb0-kQLnZH7WUdFLf0trlwJwAxFPTbjWfJrbYLkNVVhoRvewaAsJAKAvI3A0eKK73BGdqfut_hB1cOcZ0tg"
                            );

	// Pick a subreddit
	var subreddit = reddit.Subreddit("homeimprovement");

	//Set a timer to go off every 5 seconds to check for new top posts in subreddit selection
	DateTime start = DateTime.Now;
	using PeriodicTimer timer = new(TimeSpan.FromSeconds(5));
	Console.WriteLine("Top Posts for " + DateTime.Today.ToString("D") + Environment.NewLine);
	var i = 0;
	while (await timer.WaitForNextTickAsync() && i < 5)
		{
		string pageContent = "";
		var posts = subreddit?.Posts?.GetTop(new TimedCatSrListingInput(t: "hour", limit: 5));
		if (posts != null)
			{
			foreach (Post post in posts)
				{
				if (post?.Created >= DateTime.Today && post?.Created < DateTime.Today.AddDays(1))
					{
						pageContent += " [" + post?.Title + "](" + post?.Permalink + ")" + Environment.NewLine;
					}
				}
			}
		i++;
		Console.WriteLine("[" + DateTime.Now + "] "+ Environment.NewLine + pageContent );
		}





