using Domain.Model;

namespace Infra.Data
{
    public class WorkApiUnitOfWork : IUnitOfWork
    {
        private readonly WorkApiDbContext _db;

        private Repository<User> _userRepository;
        private Repository<UserAsset> _userAssetRepository;
        private Repository<Asset> _assetRepository;

        public WorkApiUnitOfWork(WorkApiDbContext context) => _db = context;

        public Repository<User> UserRepository => _userRepository ??= new Repository<User>(_db);
        public Repository<UserAsset> UserAssetRepository => _userAssetRepository ??= new Repository<UserAsset>(_db);
        public Repository<Asset> AssetRepository => _assetRepository ??= new Repository<Asset>(_db);

        public void Commit() => _db.SaveChanges();
        public void Rollback() => _db.Dispose();
    }
}
