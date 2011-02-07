using System;
using System.Collections;
using System.Collections.Generic;

namespace ManagedViewEngine.Persistence.Sql
{
    /// <summary>
    /// Borrowed from Jonathan Oliver's Event Store (https://github.com/joliver/EventStore).
    /// </summary>
    public class DisposableEnumeration<T> : IEnumerable<T>, IEnumerator<T>
	{
		private readonly ICollection<IDisposable> _resources = new IDisposable[] { };
		private readonly IEnumerator<T> _enumerator;
		private bool _disposed;

		public DisposableEnumeration(IEnumerable<T> enumerable, params IDisposable[] resources)
		{
			_enumerator = enumerable.GetEnumerator();
			_resources = resources ?? _resources;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (!disposing || _disposed)
				return;

			_disposed = true;

			foreach (var resource in _resources)
				resource.Dispose();
		}

		public virtual IEnumerator<T> GetEnumerator()
		{
			return this;
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this;
		}

		public virtual bool MoveNext()
		{
			if (this._enumerator.MoveNext())
				return true;

			this.Dispose();
			return false;
		}
		public virtual void Reset()
		{
		}

		public virtual T Current
		{
			get { return this._enumerator.Current; }
		}
		object IEnumerator.Current
		{
			get { return this._enumerator.Current; }
		}
	}
}