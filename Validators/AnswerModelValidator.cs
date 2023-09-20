﻿using api.Models.DB;
using FluentValidation;

namespace api.Validators
{
    public class AnswerModelValidator : AbstractValidator<AnswerModel>
    {
        AnswerModelValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
            RuleFor(a => a.Slug).MaximumLength(384).NotEmpty();
        }
    }
}