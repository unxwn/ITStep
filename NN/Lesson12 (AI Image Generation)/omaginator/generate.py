from pathlib import Path
import subprocess
import sys

sd_path = Path("stable-diffusion.cpp/build/bin/Release/sd.exe")
model_path = Path("models/stable-diffusion-v1-5-pruned-emaonly-Q5_0.gguf")
prompt_path = Path("prompt.txt")
output = Path("img.png")

def main():
    if not sd_path.exists():
        print(f"ERROR: sd executable not found at {sd_path}")
        sys.exit(1)
    if not model_path.exists():
        print(f"ERROR: model file not found at {model_path}")
        sys.exit(1)
    if not prompt_path.exists():
        print(f"ERROR: prompt.txt not found at {prompt_path}")
        sys.exit(1)

    prompt = prompt_path.read_text(encoding="utf-8").strip()
    if not prompt:
        print("ERROR: prompt.txt is empty")
        sys.exit(1)

    cmd = [
        str(sd_path),
        "-m", str(model_path),
        "-p", prompt,
        "-o", str(output),
        "--steps" , "50"
    ]

    print("Running command:")
    print(" ".join(cmd))

    proc = subprocess.run(cmd, capture_output=True, text=True)
    print("=== stdout ===")
    print(proc.stdout)
    print("=== stderr ===")
    print(proc.stderr)
    if proc.returncode == 0:
        print(f"Success - image saved to: {output.resolve()}")
    else:
        print(f"sd.exe exited with code {proc.returncode}. See stderr above.")

if __name__ == "__main__":
    main()
