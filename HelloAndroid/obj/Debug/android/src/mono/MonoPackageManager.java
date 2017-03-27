package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (context instanceof android.app.Application) {
				Context = context;
			}
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);
				
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	public static void setContext (Context context)
	{
		// Ignore; vestigial
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "HelloAndroid.dll" comes first in this list. */
		"HelloAndroid.dll",
		"AzureManagementLib.dll",
		"Microsoft.IdentityModel.Clients.ActiveDirectory.dll",
		"Microsoft.IdentityModel.Clients.ActiveDirectory.Platform.dll",
		"Microsoft.IdentityModel.Logging.dll",
		"Microsoft.IdentityModel.Tokens.dll",
		"Microsoft.Rest.ClientRuntime.Azure.Authentication.dll",
		"Microsoft.Rest.ClientRuntime.Azure.dll",
		"Microsoft.Rest.ClientRuntime.dll",
		"Newtonsoft.Json.dll",
		"Xamarin.Android.Support.Compat.dll",
		"Xamarin.Android.Support.Core.UI.dll",
		"Xamarin.Android.Support.v7.RecyclerView.dll",
		"Microsoft.Azure.Management.Fluent.dll",
		"Microsoft.Azure.Management.ResourceManager.Fluent.dll",
		"Microsoft.Azure.Management.Storage.Fluent.dll",
		"Microsoft.Azure.Management.Compute.Fluent.dll",
		"Microsoft.Azure.Management.Network.Fluent.dll",
		"Microsoft.Azure.Management.Batch.Fluent.dll",
		"Microsoft.Azure.Management.KeyVault.Fluent.dll",
		"Microsoft.Azure.Management.Graph.RBAC.Fluent.dll",
		"Microsoft.Azure.Management.TrafficManager.Fluent.dll",
		"Microsoft.Azure.Management.Dns.Fluent.dll",
		"Microsoft.Azure.Management.Sql.Fluent.dll",
		"Microsoft.Azure.Management.Cdn.Fluent.dll",
		"Microsoft.Azure.Management.Redis.Fluent.dll",
		"Microsoft.Azure.Management.AppService.Fluent.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_25";
}
