using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {

        private readonly TwitterCloneDbContext _context;

        public LikeRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Like AddLike(Like like)
        {
            _context.Likes.Add(like);
            _context.SaveChanges();

            return like;
        }

        public bool DeleteLike(Like like)
        {
            _context.Likes.Remove(like);
            _context.SaveChanges();
            return true;
        }

        public int DeleteLikesByUserId(Guid userId)
        {
            var likes = _context.Likes.Where(l => l.UserId == userId).ToList();
            _context.Likes.RemoveRange(likes);
            _context.SaveChanges();
            return likes.Count;
        }

        public int DeleteLikesByTweetId(Guid tweetId)
        {
            var likes = _context.Likes.Where(l => l.TweetId == tweetId).ToList();
            _context.Likes.RemoveRange(likes);
            _context.SaveChanges();
            return likes.Count;
        }

        public Like? GetLikeById(Guid id)
        {
            return _context.Likes.SingleOrDefault(l => l.Id == id);
        }

        public Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _context.Likes.FirstOrDefault(l => l.UserId == userId && l.TweetId == tweetId);
        }

        public List<Like> GetLikes(Guid? userId, Guid? tweetId)
        {
            return _context.Likes
                .Where(l => (userId == null || l.UserId == userId) &&
                            (tweetId == null || l.TweetId == tweetId))
                .ToList();
        }
    }
}
