﻿// Copyright (c) Alexander Bogarsukov.
// Licensed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Diagnostics;

namespace UnityFx.Purchasing
{
	/// <summary>
	/// A generic disposable store operation that logs start/end events.
	/// </summary>
	internal abstract class StoreOperation<T> : AsyncResult<T>
	{
		#region data

		private readonly StoreOperationContainer _parent;
		private readonly TraceEventId _traceEvent;
		private readonly string _args;

		#endregion

		#region interface

		protected StoreOperationContainer Parent => _parent;
		protected StoreService Store => _parent.Store;
		protected TraceEventId EventId => _traceEvent;

		public StoreOperation(StoreOperationContainer parent, TraceEventId eventId, string comment, string args)
		{
			_parent = parent;
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

			parent.Store.TraceSource.TraceEvent(TraceEventType.Start, (int)eventId, s);
		}

		#endregion

		#region AsyncResult

		protected override void OnCompleted()
		{
			try
			{
				var s = _traceEvent.ToString() + (IsCompletedSuccessfully ? " completed" : " failed");

				if (!string.IsNullOrEmpty(_args))
				{
					s += ": " + _args;
				}

				_parent.Store.TraceSource.TraceEvent(TraceEventType.Stop, (int)_traceEvent, s);
			}
			finally
			{
				_parent.ReleaseOperation(this);
				base.OnCompleted();
			}
		}

		#endregion

		#region implementation
		#endregion
	}
}
