
using iTin.Core.ComponentModel.Results;

namespace iTin.Core.Models
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using iTin.Core.IO;
    using iTin.Core;
    using iTin.Core.ComponentModel;
    using iTin.Core.Helpers;

    using Newtonsoft.Json;

    using NativeIO = System.IO;

    /// <summary>
    /// Base class for model elements. 
    /// Implements functionality to record and read configuration files.
    /// </summary>
    /// <typeparam name="T">Represents a model node type</typeparam>
    [Serializable]
    public class BaseModel<T>
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PropertiesModelCollection _properties;
        #endregion

        #region public readonly properties

        #region [public] (bool) PropertiesSpecified: Gets a value that tells the serializer if the referenced item is to be included
        /// <summary>
        /// Gets a value that tells the serializer if the referenced item is to be included.
        /// </summary>
        /// <value>
        /// <c>true</c> if the serializer has to include the element; otherwise, <c>false</c>.
        /// </value>
        [JsonIgnore]
        [XmlIgnore]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool PropertiesSpecified => Properties.Any();
        #endregion

        #endregion

        #region public properties

        #region [public] (PropertiesModelCollection) Properties: Gets or sets a reference to user-defined property list for this element
        /// <summary>
        /// Gets or sets a reference to user-defined property list for this element.
        /// </summary>
        /// <value>
        /// List of user-defined properties available for this element.
        /// </value>
        [XmlIgnore]
        [XmlArrayItem("Property", typeof(PropertyModel), IsNullable = false)]
        public PropertiesModelCollection Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new PropertiesModelCollection();
                }

                foreach (var property in _properties)
                {
                    property.SetOwner(_properties);
                }

                return _properties;
            }
            set => _properties = value;
        }
        #endregion

        #endregion

        #region public virtual properties

        #region [public] {virtual} (bool) IsDefault: When overridden in a derived class, gets a value indicating whether this instance contains the default
        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether this instance contains the default.
        /// </summary>
        /// <value>
        /// <strong>true</strong> if this instance contains the default; otherwise, <strong>false</strong>.
        /// </value>
        [JsonIgnore]
        [Browsable(false)]
        public virtual bool IsDefault => Properties.IsDefault;
        #endregion

        #endregion

        #region public static methods

        #region [public] {static} (T) Deserialize(string, KnownFileFormat = KnownFileFormat.Xml): Deserializes the input string into specified model type
        /// <summary>
        /// Deserializes the input string into specified model type. By default, if not specified, it will be used in <c>Xml</c> format.
        /// </summary>
        /// <param name="value">Input string</param>
        /// <param name="format">Input file format</param>
        /// <returns>
        /// A new model reference of type <c>T</c>.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static T Deserialize(string value, KnownFileFormat format = KnownFileFormat.Xml)
        {
            SentinelHelper.ArgumentNull(value, nameof(value));

            return
                format == KnownFileFormat.Xml
                    ? (T)new XmlSerializer(typeof(T)).Deserialize(XmlReader.Create(new NativeIO.StringReader(value)))
                    : JsonConvert.DeserializeObject<T>(value);
        }
        #endregion

        #region [public] {static} (T) Deserialize(Stream, KnownFileFormat = KnownFileFormat.Xml): Deserializes the input stream into specified model type
        /// <summary>
        /// Deserializes the input stream into specified model type. By default, if not specified, it will be used in <c>Xml</c> format.
        /// </summary>
        /// <param name="stream">Input stream</param>
        /// <param name="format">Input file format</param>
        /// <returns>
        /// A new model reference of type <c>T</c>.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static T Deserialize(NativeIO.Stream stream, KnownFileFormat format = KnownFileFormat.Xml)
        {
            SentinelHelper.ArgumentNull(stream, nameof(stream));

            return Deserialize(stream.AsString(), format);
        }
        #endregion

        #region [public] {static} (T) LoadFromFile(string, KnownFileFormat = KnownFileFormat.Xml): Returns a reference from a file in xml or json format
        /// <summary>
        /// Returns a reference from a file in <c>Xml</c> or <c>Json</c> format. By default, if it is not specified, it is understood that you are trying to obtain the reference from an <c>Xml</c> file.
        /// The use of the <c>~</c> character is allowed to indicate relative paths.
        /// </summary>
        /// <param name="fileName">Absolute or relative input file path</param>
        /// <param name="format">Input file format</param>
        /// <returns>
        /// A new reference that constains the model.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static T LoadFromFile(string fileName, KnownFileFormat format = KnownFileFormat.Xml)
        {
            SentinelHelper.ArgumentNull(fileName, nameof(fileName));
            SentinelHelper.IsEnumValid(format);

            NativeIO.FileStream file = null;

            try
            {
                var parsedFilenamePath = Path.PathResolver(fileName);
                var fileInfo = new NativeIO.FileInfo(parsedFilenamePath);
                bool existFile = fileInfo.Exists;
                if (!existFile)
                {
                    return default;
                }

                string value;
                file = new NativeIO.FileStream(parsedFilenamePath, NativeIO.FileMode.Open, NativeIO.FileAccess.Read);
                using (var reader = new NativeIO.StreamReader(file))
                {
                    file = null;
                    value = reader.ReadToEnd();
                }

                return Deserialize(value, format);
            }
            catch (InvalidOperationException ex)
            {
                var modelErrorMessage = new StringBuilder();
                modelErrorMessage.AppendLine(ex.Message);
                var inner = ex.InnerException;
                while (true)
                {
                    if (inner == null)
                    {
                        break;
                    }

                    modelErrorMessage.AppendLine(inner.Message);
                    inner = inner.InnerException;
                }

                throw new XmlSchemaValidationException(modelErrorMessage.ToString());
            }

            finally
            {
                file?.Dispose();
            }
        }
        #endregion

        #region [public] {static} (T) LoadFromUri(Uri, KnownFileFormat = KnownFileFormat.Xml): Returns a reference from a uri in xml or json format
        /// <summary>
        /// Returns a reference from a uri in <c>Xml</c> or <c>Json</c> format.
        /// </summary>
        /// <param name="pathUri">File path</param>
        /// <param name="format">Input file format</param>
        /// <returns>
        /// A new reference that constains the model.
        /// </returns>
        public static T LoadFromUri(Uri pathUri, KnownFileFormat format = KnownFileFormat.Xml)
        {
            SentinelHelper.ArgumentNull(pathUri, nameof(pathUri));

            return LoadFromFile(pathUri.LocalPath, format);
        }
        #endregion

        #endregion

        #region public virtual methods

        #region [public] {virtual} (IResult) SaveToFile(string, KnownFileFormat = KnownFileFormat.Xml, SaveOptions = null): Save this model in a xml or json file
        /// <summary>
        /// Save this model in a <c>Xml</c> or <c>Json</c> file. By default, if not specified, it will be saved in <c>Xml</c> format.
        /// You can indicate whether to automatically create the destination path if it does not exist. By default it will try to create the destination path.
        /// The use of the <c>~</c> character is allowed to indicate relative paths.
        /// </summary>
        /// <param name="fileName">Destination file path. Absolute or relative (~) paths are allowed</param>
        /// <param name="format">Output file format</param>
        /// <param name="options">Output model save options</param>
        /// <returns>
        /// A <see cref="IResult" /> object that contains the operation result
        /// </returns>
        public virtual IResult SaveToFile(string fileName, KnownFileFormat format = KnownFileFormat.Xml, ModelSaveOptions options = null)
        {
            SentinelHelper.ArgumentNull(fileName, nameof(fileName));
            SentinelHelper.IsEnumValid(format);

            try
            {
                var safeOptions = options;
                if (options == null)
                {
                    safeOptions = ModelSaveOptions.Default;
                }

                var candidateFullPath = Path.PathResolver(fileName);
                var filenameWithoutExtension = NativeIO.Path.GetFileNameWithoutExtension(candidateFullPath);
                var directoryName = NativeIO.Path.GetDirectoryName(candidateFullPath);
                var safeFullFilenamePath = $"{directoryName}{NativeIO.Path.DirectorySeparatorChar}{filenameWithoutExtension}.{(format == KnownFileFormat.Xml ? KnownFileFormat.Xml.ToString().ToLowerInvariant() : KnownFileFormat.Json.ToString().ToLowerInvariant())}";

                var rawModel = Serialize(safeOptions, format);

                return rawModel.AsStream(safeOptions.Encoding).SaveToFile(safeFullFilenamePath, safeOptions.ToSaveOptions());
            }
            catch (Exception ex)
            {
                return BooleanResult.FromException(ex);
            }
        }
        #endregion

        #region [public] {virtual} (string) Serialize(ModelSaveOptions, KnownFileFormat = KnownFileFormat.Xml): Returns a string that contains current model serialized in a xml or json format
        /// <summary>
        /// Returns a <see cref="string" /> that contains current model serialized in a <c>Xml</c> or <c>Json</c> format. By default, if not specified, it will be saved in <c>Xml</c> format.
        /// </summary>
        /// <param name="options">Output model save options</param>
        /// <param name="format">Output file format</param>
        /// <returns>
        /// A <see cref="string" /> that contains serialized model.
        /// </returns>
        public virtual string Serialize(ModelSaveOptions options, KnownFileFormat format = KnownFileFormat.Xml)
        {
            SentinelHelper.IsEnumValid(format);

            string value;
            string result = string.Empty;

            switch (format)
            {
                case KnownFileFormat.Xml:
                    NativeIO.MemoryStream stream = null;

                    try
                    {
                        stream = new NativeIO.MemoryStream();

                        var serializer = new XmlSerializer(typeof(T));
                        using (var writer = new NativeIO.StreamWriter(stream))
                        using (var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { Indent = options.Indent }))
                        {
                            serializer.Serialize(xmlWriter, this);

                            stream.Seek(0, NativeIO.SeekOrigin.Begin);
                            using (var streamReader = new NativeIO.StreamReader(stream))
                            {
                                stream = null;
                                value = streamReader.ReadToEnd();
                            }
                        }

                        result = value;
                    }
                    finally
                    {
                        stream?.Dispose();
                    }
                    break;

                case KnownFileFormat.Json:
                    value =
                        JsonConvert.SerializeObject(
                            this,
                            options.Indent
                                ? Newtonsoft.Json.Formatting.Indented
                                : Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                //NullValueHandling = NullValueHandling.Ignore,
                                DefaultValueHandling = DefaultValueHandling.Ignore,
                                //ContractResolver = new EmptyCollectionContractResolver(),
                            });

                    result = value;
                    break;
            }

            return result;
        }
        #endregion

        #endregion

        #region public overrides methods

        #region [public] {override} (string) ToString(): Returns a string that represents the current object
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> that represents the current object.
        /// </returns>
        public override string ToString() => !IsDefault ? "Modified" : "Default";
        #endregion

        #endregion
    }
}
