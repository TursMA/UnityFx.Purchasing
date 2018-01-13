﻿// Copyright (c) Alexander Bogarsukov.
// Licensed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Diagnostics;

namespace UnityFx.Purchasing
{
	/// <summary>
	/// A generic disposable store operation that logs start/end events.
	/// </summary>
	internal abstract class StoreOperation<T> : AsyncResult<T>, IDisposable
	{
		#region data

		private readonly TraceSource _console;
		private readonly TraceEventId _traceEvent;
		private readonly string _args;
		private bool _disposed;

		#endregion

		#region interface

		protected bool IsDisposed => _disposed;

		public StoreOperation(TraceSource console, TraceEventId eventId, string comment, string args)
		{
			_console = console;
			_traceEvent = eventId;
			_args = args;

			var s = eventId.ToString();

			if (!string.IsNullOrEmpty(comment))
			{
				s += " (" + comment + ')';
			}

			if (!string.IsNullOrEmpty(args))
			{
				s += ": " + args;
			}

			_console.TraceEvent(TraceEventType.Start, (int)eventId, s);
		}

		#endregion

		#region IDisposable

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;

				var s = _traceEvent.ToString() + (IsCompletedSuccessfully ? " completed" : " failed");

				if (!string.IsNullOrEmpty(_args))
				{
					s += ": " + _args;
				}

				_console.TraceEvent(TraceEventType.Stop, (int)_traceEvent, s);
			}
		}

		#endregion

		#region implementation
		#endregion
	}
}
