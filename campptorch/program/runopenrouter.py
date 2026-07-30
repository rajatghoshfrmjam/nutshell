from openrouter import OpenRouter
import os
import pathlib
from dotenv import load_dotenv

# Get API key from environment
# Get the current directory and load .env file
current_dir = pathlib.Path(__file__).parent.absolute()
env_path = current_dir / '.env'
load_dotenv(dotenv_path=env_path)

# Get API key from environment
api_key = os.environ.get("OPENROUTER_API_KEY")

# Check if API key is available
if not api_key:
    raise ValueError("OpenRouter API key not found. Please set OPENROUTER_API_KEY in your .env file.")

with OpenRouter(api_key) as client:
    response = client.chat.send(
        model="openai/gpt-5.2",
        messages=[
            {"role": "user", "content": "Explain quantum computing in one sentence."}
        ],
    )

    print(response.choices[0].message.content)