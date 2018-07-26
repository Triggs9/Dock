﻿using System;
using System.Collections.Generic;
using AvaloniaDemo.ReactiveUI.ViewModels.Documents;
using AvaloniaDemo.ReactiveUI.ViewModels.Tools;
using AvaloniaDemo.ReactiveUI.ViewModels.Views;
using Dock.Avalonia.Controls;
using Dock.Avalonia.Editor;
using Dock.Model;
using Dock.Model.Controls;

namespace AvaloniaDemo.ReactiveUI.ViewModels
{
    public class DemoDockFactory : DockFactory
    {
        public override IDock CreateLayout()
        {
            var document1 = new Document1
            {
                Id = "Document1",
                Title = "Document1"
            };

            var document2 = new Document2
            {
                Id = "Document2",
                Title = "Document2"
            };

            var document3 = new Document3
            {
                Id = "Document3",
                Title = "Document3"
            };

            var leftTopTool1 = new LeftTopTool1
            {
                Id = "LeftTop1",
                Title = "LeftTop1"
            };

            var leftTopTool2 = new LeftTopTool2
            {
                Id = "LeftTop2",
                Title = "LeftTop2"
            };

            var leftTopTool3 = new LeftTopTool3
            {
                Id = "LeftTop3",
                Title = "LeftTop3"
            };

            var leftBottomTool1 = new LeftBottomTool1
            {
                Id = "LeftBottom1",
                Title = "LeftBottom1"
            };

            var leftBottomTool2 = new LeftBottomTool2
            {
                Id = "LeftBottom2",
                Title = "LeftBottom2"
            };

            var leftBottomTool3 = new LeftBottomTool3
            {
                Id = "LeftBottom3",
                Title = "LeftBottom3"
            };

            var rightTopTool1 = new RightTopTool1
            {
                Id = "RightTop1",
                Title = "RightTop1"
            };

            var rightTopTool2 = new RightTopTool2
            {
                Id = "RightTop2",
                Title = "RightTop2"
            };

            var rightTopTool3 = new RightTopTool3
            {
                Id = "RightTop3",
                Title = "RightTop3"
            };

            var rightBottomTool1 = new RightBottomTool1
            {
                Id = "RightBottom1",
                Title = "RightBottom1"
            };

            var rightBottomTool2 = new RightBottomTool2
            {
                Id = "RightBottom2",
                Title = "RightBottom2"
            };

            var rightBottomTool3 = new RightBottomTool3
            {
                Id = "RightBottom3",
                Title = "RightBottom3"
            };

            var mainLayout = new LayoutDock
            {
                Id = "MainLayout",
                Title = "MainLayout",
                Proportion = double.NaN,
                Orientation = Orientation.Horizontal,
                CurrentView = null,
                Views = CreateList<IView>
                (
                    new LayoutDock
                    {
                        Id = "LeftPane",
                        Title = "LeftPane",
                        Proportion = double.NaN,
                        Orientation = Orientation.Vertical,
                        CurrentView = null,
                        Views = CreateList<IView>
                        (
                            new ToolDock
                            {
                                Id = "LeftPaneTop",
                                Title = "LeftPaneTop",
                                Proportion = double.NaN,
                                CurrentView = leftTopTool1,
                                Views = CreateList<IView>
                                (
                                    leftTopTool1,
                                    leftTopTool2,
                                    leftTopTool3
                                )
                            },
                            new SplitterDock()
                            {
                                Id = "LeftPaneTopSplitter",
                                Title = "LeftPaneTopSplitter"
                            },
                            new ToolDock
                            {
                                Id = "LeftPaneBottom",
                                Title = "LeftPaneBottom",
                                Proportion = double.NaN,
                                CurrentView = leftBottomTool1,
                                Views = CreateList<IView>
                                (
                                    leftBottomTool1,
                                    leftBottomTool2,
                                    leftBottomTool3
                                )
                            }
                        )
                    },
                    new SplitterDock()
                    {
                        Id = "LeftSplitter",
                        Title = "LeftSplitter"
                    },
                    new DocumentDock
                    {
                        Id = "DocumentsPane",
                        Title = "DocumentsPane",
                        Proportion = double.NaN,
                        CurrentView = document1,
                        Views = CreateList<IView>
                        (
                            document1,
                            document2,
                            document3
                        )
                    },
                    new SplitterDock()
                    {
                        Id = "RightSplitter",
                        Title = "RightSplitter"
                    },
                    new LayoutDock
                    {
                        Id = "RightPane",
                        Title = "RightPane",
                        Proportion = double.NaN,
                        Orientation = Orientation.Vertical,
                        CurrentView = null,
                        Views = CreateList<IView>
                        (
                            new ToolDock
                            {
                                Id = "RightPaneTop",
                                Title = "RightPaneTop",
                                Proportion = double.NaN,
                                CurrentView = rightTopTool1,
                                Views = CreateList<IView>
                                (
                                    rightTopTool1,
                                    rightTopTool2,
                                    rightTopTool3
                                )
                            },
                            new SplitterDock()
                            {
                                Id = "RightPaneTopSplitter",
                                Title = "RightPaneTopSplitter"
                            },
                            new ToolDock
                            {
                                Id = "RightPaneBottom",
                                Title = "RightPaneBottom",
                                Proportion = double.NaN,
                                CurrentView = rightBottomTool1,
                                Views = CreateList<IView>
                                (
                                    rightBottomTool1,
                                    rightBottomTool2,
                                    rightBottomTool3
                                )
                            }
                        )
                    }
                )
            };

            var mainView = new MainView
            {
                Id = "Main",
                Title = "Main",
                CurrentView = mainLayout,
                Views = CreateList<IView>(mainLayout)
            };

            var homeView = new HomeView
            {
                Id = "Home",
                Title = "Home"
            };

            var root = new RootDock
            {
                Id = "Root",
                Title = "Root",
                CurrentView = homeView,
                DefaultView = homeView,
                Views = CreateList<IView>(homeView, mainView)
            };

            return root;
        }

        public override void InitLayout(IView layout)
        {
            this.ContextLocator = new Dictionary<string, Func<object>>
            {
                [nameof(IRootDock)] = () => layout,
                [nameof(ILayoutDock)] = () => layout,
                [nameof(IDocumentDock)] = () => layout,
                [nameof(IToolDock)] = () => layout,
                [nameof(ISplitterDock)] = () => layout,
                [nameof(IDockWindow)] = () => layout,
                [nameof(IDocumentTab)] = () => layout,
                [nameof(IToolTab)] = () => layout,
                ["Document1"] = () => layout,
                ["Document2"] = () => layout,
                ["Document3"] = () => layout,
                ["LeftTop1"] = () => layout,
                ["LeftTop2"] = () => layout,
                ["LeftTop3"] = () => layout,
                ["LeftBottom1"] = () => layout,
                ["LeftBottom2"] = () => layout,
                ["LeftBottom3"] = () => layout,
                ["RightTop1"] = () => layout,
                ["RightTop2"] = () => layout,
                ["RightTop3"] = () => layout,
                ["RightBottom1"] = () => layout,
                ["RightBottom2"] = () => layout,
                ["RightBottom3"] = () => layout,
                ["LeftPane"] = () => layout,
                ["LeftPaneTop"] = () => layout,
                ["LeftPaneTopSplitter"] = () => layout,
                ["LeftPaneBottom"] = () => layout,
                ["RightPane"] = () => layout,
                ["RightPaneTop"] = () => layout,
                ["RightPaneTopSplitter"] = () => layout,
                ["RightPaneBottom"] = () => layout,
                ["DocumentsPane"] = () => layout,
                ["MainLayout"] = () => layout,
                ["LeftSplitter"] = () => layout,
                ["RightSplitter"] = () => layout,
                ["MainLayout"] = () => layout,
                ["Home"] = () => layout,
                ["Main"] = () => layout,
                ["Editor"] = () => new LayoutEditor()
                {
                    Layout = layout
                }
            };

            this.HostLocator = new Dictionary<string, Func<IDockHost>>
            {
                [nameof(IDockWindow)] = () => new HostWindow()
            };

            base.InitLayout(layout);
        }
    }
}
