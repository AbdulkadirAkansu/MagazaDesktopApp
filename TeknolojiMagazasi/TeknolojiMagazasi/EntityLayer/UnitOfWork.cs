using EntityLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UnitOfWork : IDisposable 
    {
        private readonly DBContext context;

        private MarkaRepository _markaRepo;
        private UrunRepository _urunRepo;
        private KullanıcıRepository _kullanıcıRepo;
        private MusteriRepository _musteriRepo;
        private SatısToplamRepository _satısRepo;

        public SatısToplamRepository SatısRepo
        {
            get
            {
                if (_satısRepo == null)
                    _satısRepo = new SatısToplamRepository(context);
                return _satısRepo;
            }
        }


        public MarkaRepository MarkaRepo
        {
            get
            {
                if (_markaRepo == null)
                    _markaRepo = new MarkaRepository(context);
                return _markaRepo;
            }
        }

        public UrunRepository UrunRepo
        {
            get
            {
                if (_urunRepo == null)
                    _urunRepo = new UrunRepository(context);
                return _urunRepo;
            }
        }

        public MusteriRepository MusteriRepo
        {
            get
            {
                if (_musteriRepo == null)
                    _musteriRepo = new MusteriRepository(context);
                return _musteriRepo;
            }
        }

        public KullanıcıRepository KullanıcıRepo
        {
            get
            {
                if (_kullanıcıRepo == null)
                    _kullanıcıRepo = new KullanıcıRepository(context);
                return _kullanıcıRepo;
            }
        }

        public UnitOfWork()
        {
            this.context = new DBContext();
        }

        public void Dispose()
        {
            context?.Dispose();
            _markaRepo?.Dispose();
            _urunRepo?.Dispose();
            _kullanıcıRepo?.Dispose();
            _musteriRepo?.Dispose();
            _satısRepo?.Dispose();

        }
    }
}
