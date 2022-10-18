using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentIdeasPlatform
{
    /// <summary>
    /// Class to be used to instantiate InvestmentIdea objects
    /// </summary>
    class InvestmentIdea
    {
        private String title; //Idea title
        private String overview; //Description of the idea
        private DateTime publishDate; //Date published
        private DateTime expiryDate; //Expiry date
        private String author; //Author's name (FA)
        private List<InvestmentProduct> products = new List<InvestmentProduct>(); //Will store the InvestmentProducts related to the idea, which will in turn provide more info (e.g. risk levels, etc.)

        /// <summary>
        /// Constructor for InvestmentIdea
        /// </summary>
        /// <param name="title">The title of the idea</param>
        /// <param name="overview">An overview of the idea</param>
        /// <param name="publishDate">The date the idea was published</param>
        /// <param name="expiryDate">The expiry date of the idea</param>
        /// <param name="author">The author of the idea (Fund Administrator)</param>
        /// <param name="products">A collection of products that idea encompasses</param>
        public InvestmentIdea(string title, string overview, DateTime publishDate, DateTime expiryDate, string author, List<InvestmentProduct> products)
        {
            this.title = title;
            this.overview = overview;
            this.publishDate = publishDate;
            this.expiryDate = expiryDate;
            this.author = author;
            this.products = products;
        }
    }
}
