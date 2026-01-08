using BookReviewManager.Application.Models;
using BookReviewManager.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewManager.Application.Queries
{
    public record GetBookByIdQuery(int Id)
     : IRequest<ResultVM<BookDto>>;
}
