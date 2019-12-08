 private byte[] getByteArrayFromImage(BitmapImage imageC)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            if (imageC.UriSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(imageC.UriSource));
            }
            else
            {
                encoder.Frames.Add(BitmapFrame.Create(imageC));
            }

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
                ms.Close();
                ms.Dispose();
                encoder = null;
                imageC = null;
                GC.Collect();
                return data;
            }
        }