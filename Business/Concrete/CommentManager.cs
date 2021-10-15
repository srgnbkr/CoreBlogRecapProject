using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            comment.BlogId = 4;
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = true;
            _commentDal.Add(comment);
        }

        public List<Comment> GetAll(int id)
        {
            return _commentDal.GetAll(x => x.BlogId == id);
        }
    }
}
