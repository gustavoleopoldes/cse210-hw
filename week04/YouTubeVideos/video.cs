public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;
    private int _views;
    private int _likes;
    private int _dislikes;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
        _views = 0;
        _likes = 0;
        _dislikes = 0;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    public int GetViews()
    {
        return _views;
    }

    public int GetLikes()
    {
        return _likes;
    }

    public int GetDislikes()
    {
        return _dislikes;
    }

    public void AddView()
    {
        _views++;
    }

    public void AddLike()
    {
        _likes++;
    }

    public void AddDislike()
    {
        _dislikes++;
    }

    public void AddComment(string commenterName, string commentText)
    {
        _comments.Add(new Comment(commenterName, commentText));
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public string GetEngagementStats()
    {
        return $"Views: {_views:N0} | Likes: {_likes:N0} | Dislikes: {_dislikes:N0}";
    }

    public double GetLikeRatio()
    {
        if (_likes + _dislikes == 0) return 0;
        return (double)_likes / (_likes + _dislikes) * 100;
    }
}