// VoiceGreeting.cs
// Responsible for locating and playing the recorded WAV greeting.
// Uses SoundPlayer to play the greeting audio.

using System;
using System.IO;
using System.Media;

public class VoiceGreeting
{
    // Relative path to the greeting file.
    // The greeting.wav file will be placed inside the Audio folder.
    private readonly string _relativePath = Path.Combine("Audio", "greeting.wav");

    // Plays the voice greeting when the chatbot starts.
    public void PlayGreeting()
    {
        try
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, _relativePath);

            // Check whether the audio file exists.
            if (!File.Exists(fullPath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[Voice greeting not found - continuing without audio.]");
                Console.ResetColor();
                return;
            }

            using SoundPlayer player = new SoundPlayer(fullPath);

            // Wait for the greeting to finish before continuing.
            player.PlaySync();
        }
        catch (Exception ex)
        {
            // Prevent an audio problem from crashing the chatbot.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Could not play voice greeting: {ex.Message}]");
            Console.ResetColor();
        }
    }
}