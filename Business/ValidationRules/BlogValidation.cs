using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public  class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.BlogTitle)
                .NotEmpty()
                .WithMessage("Blog Başlığı Alanı Boş Bırakılmaz")
                .MinimumLength(2)
                .WithMessage("Blog Başlığı 2 Harften Fazla Olmalıdır");

            RuleFor(x => x.BlogContent)
                .NotEmpty()
                .WithMessage("Blog İçeriği Alanı Boş Bırakılmaz")
                .MinimumLength(130)
                .WithMessage("Blog İçeriği  130 karakterden fazla olmalıdır");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Bölümü Boş Bırakılmaz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Fotoğrafı Eklemelisiniz");
               
               




        }
    }
}
