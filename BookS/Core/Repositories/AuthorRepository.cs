using System;
using System.Collections.Generic;
using System.Linq;
using BookS.Core.Maintenance;
using BookS.Core.Models;
using BookS.Core.Models.MappedClasses;
using NHibernate;
using NHibernate.Linq;

namespace BookS.Core.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorRepository : IAuthorRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultInfo<Author> Add(Author pAuthor)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    PerformAuthorValidation(pAuthor);
                    SaveAuthorToDb(session, pAuthor);

                    transaction.Commit();

                    return new ResultInfo<Author>(pAuthor)
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = "Author successfully added to the database"
                    };

                }
                catch (ResultInfoException<Author> ex)
                {
                    transaction.Rollback();
                    return ex.Result;
                }
            }
        }

        private void PerformAuthorValidation(Author pAuthor)
        {
            var validationResult = pAuthor.Validate();

            if (validationResult.Status != ValidationStatus.Success)
            {
                var resultInfo = new ResultInfo<Author>(pAuthor, new ResultInfoDecorator().WithValidationResult(validationResult))
                {
                    Status = ResultStatus.ValidationError,
                    ResultMessage = "Error occured on Author data validation process. Inspect validation result object for more details."
                };

                throw new ResultInfoException<Author>(resultInfo);
            }
        }

        private void SaveAuthorToDb(ISession pSession, Author pAuthor)
        {
            try
            {
                AuthorMapping authorMapping = (AuthorMapping)pAuthor;
                pSession.Save(authorMapping);
            }
            catch (Exception ex)
            {
                var result = new ResultInfo<Author>(pAuthor)
                {
                    Status = ResultStatus.CreationFail,
                    ResultMessage = "Error occured when saving Author to database",
                    Exception = ex
                };

                throw new ResultInfoException<Author>(result);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultInfo<Author> Update(Author pAuthor)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    UpdateAuthorInDb(session, pAuthor);

                    transaction.Commit();

                    return new ResultInfo<Author>(pAuthor);
                }
                catch (ResultInfoException<Author> ex)
                {
                    transaction.Rollback();
                    return ex.Result;
                }
            }
        }

        private void UpdateAuthorInDb(ISession pSession, Author pAuthor)
        {
            try
            {
                AuthorMapping authorMapping = (AuthorMapping)pAuthor;
                pSession.SaveOrUpdate(authorMapping);
            }
            catch (Exception ex)
            {
                var result = new ResultInfo<Author>(pAuthor)
                {
                    Status = ResultStatus.UpdateFail,
                    ResultMessage = "Error occured when updating Author entry in database",
                    Exception = ex
                };

                throw new ResultInfoException<Author>(result);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultInfo<Author> Remove(Author pAuthor)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    RemoveAuthorFromDb(session, pAuthor);

                    transaction.Commit();

                    return new ResultInfo<Author>(pAuthor)
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = "Author successfully removed from database"
                    };
                }
                catch (ResultInfoException<Author> ex)
                {
                    transaction.Rollback();

                    return ex.Result;
                }
            }
        }

        private void RemoveAuthorFromDb(ISession pSession, Author pAuthor)
        {
            try
            {
                AuthorMapping authorMapping = (AuthorMapping)pAuthor;
                pSession.Delete(authorMapping);
            }
            catch (Exception ex)
            {
                var result = new ResultInfo<Author>(pAuthor)
                {
                    Status = ResultStatus.DeleteFail,
                    ResultMessage = "Error occured when deleting Author from database",
                    Exception = ex
                };

                throw new ResultInfoException<Author>(result);
            }
        }

        /// <summary>
        /// This method allows to obtain Author from database using its unique ID.
        /// </summary>
        /// <returns>Author with given ID number or null if not found.</returns>
        public ResultInfo<Author> GetById(int pAuthorId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var author = GetAuthorsFromDbUsingPredicate(session, a => a.AuthorId == pAuthorId);

                    transaction.Commit();

                    return new ResultInfo<Author>(author.FirstOrDefault())
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = string.Format("Author with ID: {0} successfully obtained from database", pAuthorId)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new ResultInfo<Author>
                    {
                        Status = ResultStatus.SearchFail,
                        ResultMessage = string.Format("Error occured when retrieving Author with ID: {0} from database", pAuthorId),
                        Exception = ex
                    };
                }
            }
        }

        /// <summary>
        /// This method searches for all Author which writes at least in one of given genres types.
        /// </summary>
        /// <returns>Search result with Authors writing in given genres.</returns>
        public ResultInfo<IEnumerable<Author>> GetByGenres(params Genre[] pGenres)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var authors = GetAuthorsFromDbUsingPredicate(session, a => a.Books.Any(b => b.Genres.Intersect(pGenres).Count() != 0));

                    transaction.Commit();

                    return new ResultInfo<IEnumerable<Author>>(authors)
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = string.Format("{0} Authors writing in genres: {1}, successfully obtained", authors.Count(), string.Join(",", pGenres.ToList()))
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new ResultInfo<IEnumerable<Author>>
                    {
                        Status = ResultStatus.SearchFail,
                        ResultMessage = string.Format("Error occured while retrieving Authors writing in genres: {0}", string.Join(",", pGenres.ToList())),
                        Exception = ex
                    };
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDateOfBirth"></param>
        /// <returns></returns>
        public ResultInfo<IEnumerable<Author>> GetByDateOfBirth(DateTime pDateOfBirth)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var authors = GetAuthorsFromDbUsingPredicate(session, a => a.DateOfBirth == pDateOfBirth.ToString("d"));

                    transaction.Commit();

                    return new ResultInfo<IEnumerable<Author>>(authors)
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = string.Format("{0} Authors born in {1} obtained successfully", authors.Count(), pDateOfBirth)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new ResultInfo<IEnumerable<Author>>()
                    {
                        Status = ResultStatus.SearchFail,
                        ResultMessage = string.Format("Error when retrieving Author by their birth date: {0}", pDateOfBirth),
                        Exception = ex
                    };
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultInfo<IEnumerable<Author>> GetBySurname(string pSurname)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var authors = GetAuthorsFromDbUsingPredicate(session, x => x.Surname == pSurname);

                    transaction.Commit();

                    return new ResultInfo<IEnumerable<Author>>(authors)
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = string.Format("{0} Authors with surname: {1} obtained successfully", authors.Count(), pSurname)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new ResultInfo<IEnumerable<Author>>
                    {
                        Status = ResultStatus.SearchFail,
                        ResultMessage = string.Format("Error when retrieving Authors by surname: {0}", pSurname),
                        Exception = ex
                    };
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ResultInfo<IEnumerable<Author>> GetByFullName(string pFullname)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var authors = GetAuthorsFromDbUsingPredicate(session, x =>
                    {
                        var fullname = (x.Name + x.Surname).ToLower();

                        return fullname.Equals(pFullname.Trim().ToLower(), StringComparison.InvariantCulture);
                    });

                    transaction.Commit();

                    return new ResultInfo<IEnumerable<Author>>(authors)
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = string.Format("{0} Authors retrieved whose name is: {1}", authors.Count(), pFullname)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new ResultInfo<IEnumerable<Author>>
                    {
                        Status = ResultStatus.SearchFail,
                        ResultMessage = string.Format("Error when retrieving Authors by name: {0}", pFullname),
                        Exception = ex
                    };
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIsbn"></param>
        /// <returns></returns>
        public ResultInfo<IEnumerable<Author>> GetByBookIsbn(Isbn pIsbn)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var authors = GetAuthorsFromDbUsingPredicate(session, x => x.Books.Any(b => b.Isbn == pIsbn.Number));

                    transaction.Commit();

                    return new ResultInfo<IEnumerable<Author>>(authors)
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = string.Format("{0} Author retrieved by book Isbn: {1}", authors.Count(), pIsbn.Number)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new ResultInfo<IEnumerable<Author>>
                    {
                        Status = ResultStatus.SearchFail,
                        ResultMessage = string.Format("Error when retrieving Authors by book Isbn: {0}", pIsbn.Number),
                        Exception = ex
                    };
                }

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBookTitle"></param>
        /// <returns></returns>
        public ResultInfo<IEnumerable<Author>> GetByBookTitle(string pBookTitle)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    var authors = GetAuthorsFromDbUsingPredicate(session, x => x.Books.Any(b => b.Title == pBookTitle));

                    transaction.Commit();

                    return new ResultInfo<IEnumerable<Author>>(authors)
                    {
                        Status = ResultStatus.Success,
                        ResultMessage = string.Format("{0} Authors retrieved which have written book: {1}", authors.Count(), pBookTitle)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new ResultInfo<IEnumerable<Author>>
                    {
                        Status = ResultStatus.SearchFail,
                        ResultMessage = string.Format("Error when retrieving Authors which have written book: {0}", pBookTitle),
                        Exception = ex 
                    };
                }
            }
        }

        private IEnumerable<Author> GetAuthorsFromDbUsingPredicate(ISession pSession, Func<AuthorMapping, bool> pPredicate)
        {
            return pSession.Query<AuthorMapping>().Where(pPredicate);
        }
    }
}
