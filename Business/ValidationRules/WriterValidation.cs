using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class WriterValidation : AbstractValidator<Writer>
    {
        public WriterValidation()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim Kısmı Boş Geçilemez");
            RuleFor(x => x.WriterMail)
                .NotEmpty()
                .WithMessage("Email Alanı Boş Olmamalı")
                .EmailAddress()
                .WithMessage("Geçerisz Email");
            RuleFor(x => x.WriterPassword)
                .NotEmpty()
                .WithMessage("Şifre Alanı Boş Olmamalı")
                .MinimumLength(6)
                .WithMessage("Şifre En Az 3 Karakter Uzunluğunda Olmalı");



            RuleFor(x => x.WriterConfirmPassword)
                .NotEmpty()
                .WithMessage("Şifre Tekrar Alanı Boş Olmamalı")
                .Equal(x => x.WriterPassword)
                .WithMessage("Şifreler Aynı Olmak Zorundadır");

            RuleFor(x => x.WriterPassword)
                .Matches(@"[A-Z]+")
                .WithMessage("En Az 1 Büyük Harf Olmalı.");
            RuleFor(x => x.WriterPassword)
                .Matches(@"[a-z]+")
                .WithMessage("En Az 1 Küçük Harf Olmalı.");
            RuleFor(x => x.WriterPassword)
                .Matches(@"[0-9]+")
                .WithMessage("En Az 1 Sayı Olmalı.");
            


        }
    }
}
