﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;

namespace Dock.Model
{
    /// <summary>
    /// Dock factory contract.
    /// </summary>
    public interface IDockFactory
    {
        /// <summary>
        /// Gets or sets <see cref="IDock.Context"/> locator registry.
        /// </summary>
        IDictionary<string, Func<object>> ContextLocator { get; set; }

        /// <summary>
        /// Gets or sets <see cref="IDockHost"/> locator registry.
        /// </summary>
        IDictionary<string, Func<IDockHost>> HostLocator { get; set; }

        /// <summary>
        /// Gets context.
        /// </summary>
        /// <param name="id">The object id.</param>
        /// <param name="context">The default context.</param>
        /// <returns>The located context or default context.</returns>
        object GetContext(string id, object context);

        /// <summary>
        /// Gets host.
        /// </summary>
        /// <param name="id">The host id.</param>
        /// <returns>The located host.</returns>
        IDockHost GetHost(string id);

        /// <summary>
        /// Updates window.
        /// </summary>
        /// <param name="window">The window to update.</param>
        /// <param name="context">The context object.</param>
        /// <param name="owner">The window owner dock.</param>
        void Update(IDockWindow window, object context, IDock owner);

        /// <summary>
        /// Updates windows.
        /// </summary>
        /// <param name="windows">The windows to update.</param>
        /// <param name="context">The context object.</param>
        /// <param name="owner">The window owner dock.</param>
        void Update(IList<IDockWindow> windows, object context, IDock owner);

        /// <summary>
        /// Update view.
        /// </summary>
        /// <param name="view">The view to update.</param>
        /// <param name="context">The context object.</param>
        /// <param name="parent">The view parent dock.</param>
        void Update(IDock view, object context, IDock parent);

        /// <summary>
        /// Updates views.
        /// </summary>
        /// <param name="views">The views to update.</param>
        /// <param name="context">The context object.</param>
        /// <param name="parent">The view parent dock.</param>
        void Update(IList<IDock> views, object context, IDock parent);

        /// <summary>
        /// Removes dock from parent <see cref="IDockNavigation.Views"/> collection.
        /// </summary>
        /// <param name="dock">The dock to remove.</param>
        void Remove(IDock dock);

        /// <summary>
        /// Move dock to the destination parent <see cref="IDockNavigation.Views"/> collection.
        /// </summary>
        /// <param name="dock">The dock to move.</param>
        /// <param name="parent">The destination parent.</param>
        void Move(IDock dock, IDock parent);

        /// <summary>
        /// Replaces source dock with destination dock in source dock parent <see cref="IDockNavigation.Views"/> collection.
        /// </summary>
        /// <param name="source">The source dock.</param>
        /// <param name="destination">The destination dock.</param>
        void Replace(IDock source, IDock destination);

        /// <summary>
        /// Splits dock and updates parent layout.
        /// </summary>
        /// <param name="dock">The dock to perform operation on.</param>
        /// <param name="operation"> The dock operation to perform.</param>
        void Split(IDock dock, DockOperation operation);

        /// <summary>
        /// Splits dock to the <see cref="DockOperation.Fill"/> and updates <see cref="IDock.Parent"/> layout.
        /// </summary>
        /// <param name="dock">The dock to perform operation on.</param>
        void SplitToFill(IDock dock);

        /// <summary>
        /// Splits dock to the <see cref="DockOperation.Left"/> and updates <see cref="IDock.Parent"/> layout.
        /// </summary>
        /// <param name="dock">The dock to perform operation on.</param>
        void SplitToLeft(IDock dock);

        /// <summary>
        /// Splits dock to the <see cref="DockOperation.Right"/> and updates <see cref="IDock.Parent"/> layout.
        /// </summary>
        /// <param name="dock">The dock to perform operation on.</param>
        void SplitToRight(IDock dock);

        /// <summary>
        /// Splits dock to the <see cref="DockOperation.Top"/> and updates <see cref="IDock.Parent"/> layout.
        /// </summary>
        /// <param name="dock">The dock to perform operation on.</param>
        void SplitToTop(IDock dock);

        /// <summary>
        /// Splits dock to the <see cref="DockOperation.Bottom"/> and updates <see cref="IDock.Parent"/> layout.
        /// </summary>
        /// <param name="dock">The dock to perform operation on.</param>
        void SplitToBottom(IDock dock);

        /// <summary>
        /// Splits dock to the <see cref="DockOperation.Window"/> and updates <see cref="IDock.Parent"/> layout.
        /// </summary>
        /// <param name="dock">The dock to perform operation on.</param>
        void SplitToWindow(IDock dock);

        /// <summary>
        /// Converts dock to <see cref="IDockLayout"/> type.
        /// </summary>
        /// <param name="dock">The dock to convert.</param>
        void ConvertToLayout(IDock dock);

        /// <summary>
        /// Converts dock to <see cref="IDockRoot"/> type.
        /// </summary>
        /// <param name="dock">The dock to convert.</param>
        void ConvertToRoot(IDock dock);

        /// <summary>
        /// Converts dock to <see cref="IDockSplitter"/> type.
        /// </summary>
        /// <param name="dock">The dock to convert.</param>
        void ConvertToSplitter(IDock dock);

        /// <summary>
        /// Converts dock to <see cref="IDockStrip"/> type.
        /// </summary>
        /// <param name="dock">The dock to convert.</param>
        void ConvertToStrip(IDock dock);

        /// <summary>
        /// Converts dock to <see cref="IDockView"/> type.
        /// </summary>
        /// <param name="dock">The dock to convert.</param>
        void ConvertToView(IDock dock);

        /// <summary>
        /// Creates layout.
        /// </summary>
        /// <returns>The new instance of the <see cref="IDock"/> class.</returns>
        IDock CreateLayout();

        /// <summary>
        /// Initialize layout.
        /// </summary>
        /// <param name="layout">The layout to initialize.</param>
        /// <param name="context">The context object.</param>
        void InitLayout(IDock layout, object context);
    }
}
