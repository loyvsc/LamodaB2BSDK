using LamodaB2BSDK.Helpers;
using LamodaB2BSDK.Primitives.Interfaces;

namespace LamodaB2BSDK.Primitives.Models;

public abstract class Service<TEntityReturned> : 
    INestedCreatable<TEntityReturned>, 
    INestedUpdatable<TEntityReturned>,
    IListable<TEntityReturned,ListOptions>,
    IDisposable where TEntityReturned : ILamodaEntity
    {
        private protected readonly HttpHelper _httpHelper = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{EntityReturned}"/> class with a
        /// custom <see cref="IClient"/>.
        /// </summary>
        /// <param name="client">The client used by the service to send requests.</param>
        protected Service(IClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Client base url
        /// </summary>
        public virtual string BaseUrl => Client.ApiBase;

        /// <summary>
        /// Gets or sets the client used by this service to send requests. If no client was set when the
        /// service instance was created, then the default client in
        /// <see cref="Client"/> is used instead.
        /// </summary>
        /// <remarks>
        /// Setting the client at runtime may not be thread-safe.
        /// If you wish to use a custom client, it is recommended that you pass it to the service's constructor and not change it during the service's lifetime.
        /// </remarks>
        public IClient Client { get; set; }

        protected RequestOptions SetupRequestOptions(RequestOptions? requestOptions)
        {
            requestOptions ??= new RequestOptions(BaseUrl);
            
            return requestOptions;
        }
        
        public TEntityReturned Create(string url, TEntityReturned entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntityReturned> CreateAsync(string url, TEntityReturned entity, CancellationToken? cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TEntityReturned Update(string url, TEntityReturned entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntityReturned> UpdateAsync(string url, TEntityReturned entity, CancellationToken? cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public List<TEntityReturned> List(ListOptions? listOptions = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntityReturned>> ListAsync(ListOptions? listOptions = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntityReturned> ListAutoPaging(ListOptions? listOptions = null)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<TEntityReturned> ListAutoPagingAsync(ListOptions? listOptions = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _httpHelper.Dispose();
        }
    }