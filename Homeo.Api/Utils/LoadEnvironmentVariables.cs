namespace Homeo.Utils {
    public static class LoadEnvironmentVariables {
        /// <summary>
        /// Loads a dot.env file and set the environment variables that are included on it
        /// </summary>
        /// <param name="path">A <see cref="string"/> that represent the file path</param>
        /// <exception cref="IOException">The exception to be thrown if the file was not found</exception>
        /// <exception cref="Exception">The exception to be thrown if the file is not properly formatted</exception>
        public static void Load(string path) {
            if (!File.Exists(path)) throw new IOException(".env file was not found");

            foreach(var line in File.ReadAllLines(path)) {
                string[] split = line.Split('=');
                if (split.Length != 2) continue;
                
                string property = split[0];
                string value = split[1];

                Environment.SetEnvironmentVariable(property, value);
            }
        }
    }
}
