﻿/*
 * Copyright (c) 2014 RocketLauncher <https://github.com/BenDol/RocketLauncher>
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Launcher {
    class Xml {
        /**
         * Static load specific xml document
         **/
        public static XDocument load(String file) {
            XDocument xml = null;
            try {
                if (File.Exists(file)) {
                    xml = XDocument.Load(file);
                }
                else {
                    throw new FileNotFoundException("The file " + file + " does not exist.");
                }
            }
            catch (IOException e) {
                Logger.log(Logger.TYPE.WARN, e.Message + e.StackTrace);
            }

            return xml;
        }

        public static String getAttributeValue(XAttribute attr, String optional = null) {
            if (optional == null) {
                try {
                    return attr.Value.Trim();
                } catch (NullReferenceException) {
                    throw new MissingAttributeException(attr.BaseUri, attr.Name.LocalName);
                }
            } else {
                return (attr != null && attr.Value != null) ? attr.Value.Trim() : optional;
            }
        }
    }
}
