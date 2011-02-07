﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventStore.Persistence.SqlPersistence.SqlDialects {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AccessStatements {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AccessStatements() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("EventStore.Persistence.SqlPersistence.SqlDialects.AccessStatements", typeof(AccessStatements).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT C.StreamId, MAX(C.StreamRevision) AS StreamRevision, MAX(IIf(S.StreamRevision IS NULL, 0, S.StreamRevision)) AS SnapshotRevision
        ///  FROM Commits AS C
        /// LEFT JOIN Snapshots AS S
        ///    ON ( C.StreamId = S.StreamId AND C.StreamRevision &gt;= S.StreamRevision )
        /// GROUP BY C.StreamId
        ///HAVING MAX(C.StreamRevision) &gt;= MAX(IIf(S.StreamRevision IS NULL, 0, S.StreamRevision)) + @Threshold;.
        /// </summary>
        internal static string GetStreamsToSnapshot {
            get {
                return ResourceManager.GetString("GetStreamsToSnapshot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Dual
        ///(
        ///       DualTableValue char(1) NOT NULL
        ///);
        ///INSERT INTO Dual VALUES (&apos; &apos;);
        ///
        ///CREATE TABLE Commits
        ///(
        ///       StreamId guid NOT NULL,
        ///       StreamRevision int NOT NULL,
        ///       Items tinyint NOT NULL,
        ///       CommitId guid NOT NULL,
        ///       CommitSequence int NOT NULL,
        ///       CommitStamp decimal NOT NULL,
        ///       Dispatched bit NOT NULL DEFAULT 0,
        ///       Headers image NULL,
        ///       Payload image NOT NULL,
        ///       CONSTRAINT PK_Commits PRIMARY KEY (StreamId, CommitSequence)
        ///);
        ///CRE [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InitializeStorage {
            get {
                return ResourceManager.GetString("InitializeStorage", resourceCulture);
            }
        }
    }
}
