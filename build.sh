dotnet tool restore

# Build once and install the Python packages
dotnet fable --lang py
pip install -r fable_modules/requirements.txt

dotnet fable watch --lang py --runWatch program.py "$@"
