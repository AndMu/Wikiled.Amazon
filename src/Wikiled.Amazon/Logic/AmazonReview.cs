
using System;

namespace Wikiled.Amazon.Logic
{
    public class AmazonReview
    {
        private AmazonReview()
        {
        }

        public static AmazonReview ContructNew(ProductData product, UserData user, AmazonReviewData data, AmazonTextData textData)
        {
            var review = Construct(product, user, data, textData);
            review.Data.Id = $"{product.Id}:{user.Id}";
            review.Data.ProductId = product.Id;
            review.Data.UserId = user.Id;
            review.TextData.Id = review.Id;
            return review;
        }

        public static AmazonReview Construct(
            ProductData product, 
            UserData user, 
            AmazonReviewData data, 
            AmazonTextData textData)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(product.Id))
            {
                throw new ArgumentException(nameof(product.Id));
            }

            if (string.IsNullOrEmpty(user.Id))
            {
                throw new ArgumentException(nameof(user.Id));
            }

            AmazonReview review = new AmazonReview();
            review.Data = data ?? throw new ArgumentNullException(nameof(data));
            review.Product = product;
            review.User = user;
            review.TextData = textData ?? throw new ArgumentNullException(nameof(textData));
            return review;
        }

        public string Id => Data.Id;

        public AmazonTextData TextData { get; private set; }

        public AmazonReviewData Data { get; private set; }

        public ProductData Product { get; private set; }

        public UserData User { get; private set; }
    }
}
