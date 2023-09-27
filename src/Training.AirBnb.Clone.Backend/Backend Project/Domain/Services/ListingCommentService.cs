﻿using Backend_Project.Domain.Entities;
using Backend_Project.Domain.Exceptions.ListingReviewException;
using Backend_Project.Domain.Interfaces;
using Backend_Project.Persistance.DataContexts;
using System.Linq.Expressions;

namespace Backend_Project.Domain.Services
{
    public class ListingCommentService : IEntityBaseService<ListingComment>
    {
        private readonly IDataContext _appDataContext;

        public ListingCommentService(IDataContext appDataContext)
        {
            _appDataContext = appDataContext;
        }

        public async ValueTask<ListingComment> CreateAsync(ListingComment listingComment, bool saveChanges = true)
        {
            if (!(await IsValidComment(listingComment.Comment)))
                throw new ListingCommentFormatException("Invalid comment!");
            
            await _appDataContext.ListingComments.AddAsync(listingComment);
            
            if (saveChanges)
                await _appDataContext.ListingComments.SaveChangesAsync();
            return listingComment;
        }

        public async ValueTask<ListingComment> DeleteAsync(Guid id, bool saveChanges = true)
        {
            var deletedListingReview = await GetByIdAsync(id);

            if (deletedListingReview is null)
                throw new ListingCommentNotFoundException("ListingComment not found!");

            deletedListingReview.IsDeleted = true;
            deletedListingReview.DeletedDate = DateTimeOffset.UtcNow;
            
            if (saveChanges)
                await _appDataContext.ListingComments.SaveChangesAsync();
            return deletedListingReview;
        }

        public async ValueTask<ListingComment> DeleteAsync(ListingComment listingComment, bool saveChanges = true)
        {
            var deletedListingComment = await GetByIdAsync(listingComment.Id);

            if (deletedListingComment is null)
                throw new ListingCommentNotFoundException("ListingComment not found!");

            deletedListingComment.IsDeleted = true;
            deletedListingComment.DeletedDate= DateTimeOffset.UtcNow;

            if (saveChanges)
                await _appDataContext.ListingComments.SaveChangesAsync();
            return deletedListingComment;
        }

        public IQueryable<ListingComment> Get(Expression<Func<ListingComment, bool>> predicate)
        {
            return GetUndeletedListingComment().Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<ListingComment>> GetAsync(IEnumerable<Guid> ids)
        {
            var listigComments = GetUndeletedListingComment().
                Where(listingComment => ids.Contains(listingComment.Id));
            return new ValueTask<ICollection<ListingComment>>(listigComments.ToList());
        }

        public ValueTask<ListingComment> GetByIdAsync(Guid id)
        {
            return new ValueTask<ListingComment>(GetUndeletedListingComment().
                FirstOrDefault(listingComment => listingComment.Id == id) ??
                throw new ListingCommentNotFoundException("ListingComment not found!"));
        }

        public async ValueTask<ListingComment> UpdateAsync(ListingComment listingComment, bool saveChanges = true)
        {
            var updatedListingComment = GetUndeletedListingComment().
                FirstOrDefault(updateListingComment => listingComment.Id.Equals(updateListingComment.Id));

            if (updatedListingComment is null)
                throw new ListingCommentNotFoundException("ListingComment not found!");
            if (!(await IsValidComment(listingComment.Comment)))
                throw new ListingCommentFormatException("Invalid comment!");

            updatedListingComment.Comment = listingComment.Comment;
            updatedListingComment.ModifiedDate = DateTimeOffset.UtcNow;
            
            if (saveChanges)
                await _appDataContext.ListingComments.SaveChangesAsync();
            return updatedListingComment;
        }

        private ValueTask<bool> IsValidComment(string comment)
        {
            if (!string.IsNullOrWhiteSpace(comment) && comment.Length < 1000)
                return new ValueTask<bool>(true);
            else return new ValueTask<bool>(false);
        }

        private IQueryable<ListingComment> GetUndeletedListingComment() =>_appDataContext.ListingComments.
            Where(listingComment => !listingComment.IsDeleted).AsQueryable();
    }
}
