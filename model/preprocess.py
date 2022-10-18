import os
import argparse
import shutil
from pathlib import Path

import matplotlib.pyplot as plt
from pydicom import dcmread
from pydicom.pixel_data_handlers.util import apply_modality_lut

def dicom_to_image(in_dir, out_dir, HU=False):
    if os.path.isdir(out_dir):
        shutil.rmtree(out_dir)

    os.makedirs(out_dir)
    
    file = Path(in_dir)
    dcms = [f for f in file.iterdir()]

    for index, path in enumerate(dcms):
        ds = dcmread(str(path))
        file_name = ds.Modality + "_" + ds.SOPInstanceUID

        if HU:
            hu_image = apply_modality_lut(ds.pixel_array, ds)
            vmin = ds.WindowCenter - ds.WindowWidth/2
            vmax = ds.WindowCenter + ds.WindowWidth/2

            plt.imsave((out_dir + "/" + file_name + ".bmp"), hu_image, cmap='gray', vmin=vmin, vmax=vmax)
        else:
            plt.imsave((out_dir + "/" + file_name + ".bmp"), ds.pixel_array, cmap='gray')

        print(index+1)
    

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("source", type=str, help="dicom dir path")
    parser.add_argument("--output", type=str, default="temp/images", help="save to output path")
    parser.add_argument("--HU", action="store_true", help="convert to HU image")

    opt = parser.parse_args()

    dicom_to_image(in_dir=opt.source, out_dir=opt.output, HU=opt.HU)