# EFCoreMigrationIssue

Minimal code project to recreate a nullreferenceexception thrown when executing migrations on devices for a Xamarin Android/iOS project.

Migrations generated using the following CLI commands from `EFCoreMigrationIssue.Persistence` (see https://github.com/ngrumbine/EFDemo for further details):
```
$> dotnet restore
$> dotnet ef  -v migrations add <MigrationName> --startup-project ../DbConsole/
```

iOS Migration failure stacktrace:
```
System.NullReferenceException: Object reference not set to an instance of an object
  at SQLitePCL.raw.sqlite3_open_v2 (SQLitePCL.utf8z filename, SQLitePCL.sqlite3& db, System.Int32 flags, SQLitePCL.utf8z vfs) [0x00000] in <20c60171f1e84dae90646bc69aa016a2>:0
  at SQLitePCL.raw.sqlite3_open_v2 (System.String filename, SQLitePCL.sqlite3& db, System.Int32 flags, System.String vfs) [0x0000e] in <20c60171f1e84dae90646bc69aa016a2>:0
  at Microsoft.Data.Sqlite.SqliteConnection.Open () [0x00122] in <4595d52549d54c96abd42a829433f17f>:0
  at Microsoft.EntityFrameworkCore.Storage.RelationalConnection.OpenDbConnection (System.Boolean errorsExpected) [0x00068] in <f5204d66c5e44e97800be3bcdcbea83c>:0
  at Microsoft.EntityFrameworkCore.Storage.RelationalConnection.Open (System.Boolean errorsExpected) [0x00042] in <f5204d66c5e44e97800be3bcdcbea83c>:0
  at Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal.SqliteDatabaseCreator.Exists () [0x0000c] in <f76a2b97c8554f5e90ec296c33c19378>:0
  at Microsoft.EntityFrameworkCore.Migrations.HistoryRepository.Exists () [0x0000b] in <f5204d66c5e44e97800be3bcdcbea83c>:0
  at Microsoft.EntityFrameworkCore.Migrations.Internal.Migrator.Migrate (System.String targetMigration) [0x00012] in <f5204d66c5e44e97800be3bcdcbea83c>:0
  at Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.Migrate (Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade databaseFacade) [0x00010] in <f5204d66c5e44e97800be3bcdcbea83c>:0
  at EFCoreMigrationIssue.Persistence.EFCoreMigrationIssueDbContext..ctor (System.String databasePath) [0x0000f] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.Persistence/EFCoreMigrationIssueDbContext.cs:13
  at EFCoreMigrationIssue.Persistence.FooRepository.GetDbContext () [0x00001] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.Persistence/FooRepository.cs:32
  at EFCoreMigrationIssue.Persistence.FooRepository.GetAll () [0x00001] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.Persistence/FooRepository.cs:25
  at EFCoreMigrationIssue.MainPage.LoadFooList () [0x00001] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue/MainPage.xaml.cs:36
  at EFCoreMigrationIssue.MainPage..ctor () [0x0003e] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue/MainPage.xaml.cs:27
  at EFCoreMigrationIssue.App..ctor () [0x0000f] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue/App.xaml.cs:13
  at EFCoreMigrationIssue.iOS.AppDelegate.FinishedLaunching (UIKit.UIApplication app, Foundation.NSDictionary options) [0x00007] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.iOS/AppDelegate.cs:26
  at at (wrapper managed-to-native) UIKit.UIApplication.UIApplicationMain(int,string[],intptr,intptr)
  at UIKit.UIApplication.Main (System.String[] args, System.IntPtr principal, System.IntPtr delegate) [0x00005] in /Library/Frameworks/Xamarin.iOS.framework/Versions/13.6.0.12/src/Xamarin.iOS/UIKit/UIApplication.cs:86
  at UIKit.UIApplication.Main (System.String[] args, System.String principalClassName, System.String delegateClassName) [0x0000e] in /Library/Frameworks/Xamarin.iOS.framework/Versions/13.6.0.12/src/Xamarin.iOS/UIKit/UIApplication.cs:65
  at EFCoreMigrationIssue.iOS.Application.Main (System.String[] args) [0x00001] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.iOS/Main.cs:17
```

Android Migration Failure Stacktrace:
```
System.TypeLoadException: Could not resolve type with token 01000143 from typeref (expected class 'System.Diagnostics.CodeAnalysis.MaybeNullAttribute' in assembly 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51')
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.NonNullableReferencePropertyConvention.Process (Microsoft.EntityFrameworkCore.Metadata.Builders.IConventionPropertyBuilder propertyBuilder) [0x00016] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.NonNullableReferencePropertyConvention.ProcessPropertyAdded (Microsoft.EntityFrameworkCore.Metadata.Builders.IConventionPropertyBuilder propertyBuilder, Microsoft.EntityFrameworkCore.Metadata.Conventions.IConventionContext`1[TMetadata] context) [0x00000] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ImmediateConventionScope.OnPropertyAdded (Microsoft.EntityFrameworkCore.Metadata.Builders.IConventionPropertyBuilder propertyBuilder) [0x00057] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+RunVisitor.VisitOnPropertyAdded (Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+OnPropertyAddedNode node) [0x00011] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+OnPropertyAddedNode.Accept (Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ConventionVisitor visitor) [0x00000] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ConventionVisitor.Visit (Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ConventionNode node) [0x00005] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ConventionVisitor.VisitConventionScope (Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ConventionScope node) [0x00021] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ConventionBatch.Run () [0x000e6] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ConventionBatch.Dispose () [0x0001d] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher+ImmediateConventionScope.OnModelInitialized (Microsoft.EntityFrameworkCore.Metadata.Builders.IConventionModelBuilder modelBuilder) [0x0006f] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal.ConventionDispatcher.OnModelInitialized (Microsoft.EntityFrameworkCore.Metadata.Builders.IConventionModelBuilder modelBuilder) [0x00000] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Metadata.Internal.Model..ctor (Microsoft.EntityFrameworkCore.Metadata.Conventions.ConventionSet conventions) [0x0006d] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.ModelBuilder..ctor (Microsoft.EntityFrameworkCore.Metadata.Conventions.ConventionSet conventions) [0x00012] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Infrastructure.ModelSource.CreateModel (Microsoft.EntityFrameworkCore.DbContext context, Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure.IConventionSetBuilder conventionSetBuilder) [0x00012] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Infrastructure.ModelSource+<>c__DisplayClass5_0.<GetModel>b__1 () [0x00000] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at System.Lazy`1[T].ViaFactory (System.Threading.LazyThreadSafetyMode mode) [0x00043] in <46c2fa109b574c7ea6739f9fe2350976>:0
  at System.Lazy`1[T].ExecutionAndPublication (System.LazyHelper executionAndPublication, System.Boolean useDefaultConstructor) [0x00022] in <46c2fa109b574c7ea6739f9fe2350976>:0
  at System.Lazy`1[T].CreateValue () [0x00074] in <46c2fa109b574c7ea6739f9fe2350976>:0
  at System.Lazy`1[T].get_Value () [0x0000a] in <46c2fa109b574c7ea6739f9fe2350976>:0
  at Microsoft.EntityFrameworkCore.Infrastructure.ModelSource.GetModel (Microsoft.EntityFrameworkCore.DbContext context, Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure.IConventionSetBuilder conventionSetBuilder) [0x00048] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Internal.DbContextServices.CreateModel () [0x0003c] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Internal.DbContextServices.get_Model () [0x00020] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Infrastructure.EntityFrameworkServicesBuilder+<>c.<TryAddCoreServices>b__7_3 (System.IServiceProvider p) [0x00006] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitFactory (Microsoft.Extensions.DependencyInjection.ServiceLookup.FactoryCallSite factoryCallSite, Microsoft.Extensions.DependencyInjection.ServiceLookup.RuntimeResolverContext context) [0x0000d] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2[TArgument,TResult].VisitCallSiteMain (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite callSite, TArgument argument) [0x00033] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite callSite, Microsoft.Extensions.DependencyInjection.ServiceLookup.RuntimeResolverContext context, Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope serviceProviderEngine, Microsoft.Extensions.DependencyInjection.ServiceLookup.RuntimeResolverLock lockType) [0x00059] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite singletonCallSite, Microsoft.Extensions.DependencyInjection.ServiceLookup.RuntimeResolverContext context) [0x00029] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2[TArgument,TResult].VisitCallSite (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite callSite, TArgument argument) [0x00057] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor (Microsoft.Extensions.DependencyInjection.ServiceLookup.ConstructorCallSite constructorCallSite, Microsoft.Extensions.DependencyInjection.ServiceLookup.RuntimeResolverContext context) [0x0002c] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2[TArgument,TResult].VisitCallSiteMain (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite callSite, TArgument argument) [0x0004f] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitCache (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite callSite, Microsoft.Extensions.DependencyInjection.ServiceLookup.RuntimeResolverContext context, Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope serviceProviderEngine, Microsoft.Extensions.DependencyInjection.ServiceLookup.RuntimeResolverLock lockType) [0x00059] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScopeCache (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite singletonCallSite, Microsoft.Extensions.DependencyInjection.ServiceLookup.RuntimeResolverContext context) [0x00029] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2[TArgument,TResult].VisitCallSite (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite callSite, TArgument argument) [0x00057] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceCallSite callSite, Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope scope) [0x00012] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.DynamicServiceProviderEngine+<>c__DisplayClass1_0.<RealizeService>b__0 (Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope scope) [0x0003e] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.GetService (System.Type serviceType, Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope serviceProviderEngineScope) [0x0003d] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService (System.Type serviceType) [0x00013] in <afb136dae6154b1f956a9d6c25d25974>:0
  at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService (System.IServiceProvider provider, System.Type serviceType) [0x00034] in <f42dc3743e9a40bbad437e55b425d408>:0
  at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T] (System.IServiceProvider provider) [0x0000e] in <f42dc3743e9a40bbad437e55b425d408>:0
  at Microsoft.EntityFrameworkCore.DbContext.get_DbContextDependencies () [0x00017] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.DbContext.get_InternalServiceProvider () [0x000b5] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.DbContext.Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure<System.IServiceProvider>.get_Instance () [0x00000] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade.Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure<System.IServiceProvider>.get_Instance () [0x00000] in <42de1eb635af4acabe9ad4af5d123ec7>:0
  at Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.GetRelationalService[TService] (Microsoft.EntityFrameworkCore.Infrastructure.IInfrastructure`1[T] databaseFacade) [0x0000c] in <f5204d66c5e44e97800be3bcdcbea83c>:0
  at Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions.Migrate (Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade databaseFacade) [0x0000b] in <f5204d66c5e44e97800be3bcdcbea83c>:0
  at EFCoreMigrationIssue.Persistence.EFCoreMigrationIssueDbContext..ctor (System.String databasePath) [0x0000f] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.Persistence/EFCoreMigrationIssueDbContext.cs:13
  at EFCoreMigrationIssue.Persistence.FooRepository.GetDbContext () [0x00001] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.Persistence/FooRepository.cs:32
  at EFCoreMigrationIssue.Persistence.FooRepository.GetAll () [0x00001] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.Persistence/FooRepository.cs:25
  at EFCoreMigrationIssue.MainPage.LoadFooList () [0x00001] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue/MainPage.xaml.cs:36
  at EFCoreMigrationIssue.MainPage..ctor () [0x0003e] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue/MainPage.xaml.cs:27
  at EFCoreMigrationIssue.App..ctor () [0x0000f] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue/App.xaml.cs:13
  at EFCoreMigrationIssue.Droid.MainActivity.OnCreate (Android.OS.Bundle savedInstanceState) [0x0002f] in /Users/dev3/Virtual Machines.localized/shared/stackoverflow_samples/EFCoreMigrationIssue/EFCoreMigrationIssue.Android/MainActivity.cs:24
  at Android.App.Activity.n_OnCreate_Landroid_os_Bundle_ (System.IntPtr jnienv, System.IntPtr native__this, System.IntPtr native_savedInstanceState) [0x00011] in <8c07a09624c14764b43f6b946a5a1f23>:0
  at at (wrapper dynamic-method) Android.Runtime.DynamicMethodNameCounter.8(intptr,intptr,intptr)

```
