using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using NAudio.Wave;
using NReco.VideoConverter;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DiscordVocalSender
{
    public partial class Form1 : Form
    {
        string filePath = "";
        string base64 = "AACbLjoAAA==";
        Process process;

        public static string GenerateWaveform(string inputFilePath, int intensity)
        {
            using (var reader = new AudioFileReader(inputFilePath))
            {
                var samples = new float[reader.Length / reader.WaveFormat.BlockAlign];
                reader.Read(samples, 0, (int)reader.Length / reader.WaveFormat.BlockAlign);

                var max = 0f;
                for (int i = 0; i < samples.Length; i++)
                {
                    var sample = Math.Abs(samples[i]);
                    if (sample > max)
                        max = sample;
                }

                var waveformBuilder = new StringBuilder();
                
                for (int i = 0; i < samples.Length; i += samples.Length / 50)
                {
                    var sample = Math.Abs(samples[i]) * intensity;
                    var scaledSample = (int)(sample / max * 100);
                    waveformBuilder.Append(Convert.ToChar(scaledSample));
                }


                return Convert.ToBase64String(Encoding.UTF8.GetBytes(waveformBuilder.ToString()));
            }
        }

        public Form1()
        {
            InitializeComponent();
            TokenBox.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.Title = "Select Audio File";
            ofd1.InitialDirectory = @"C:\";
            ofd1.Filter = "OGG File (*.ogg)|*.ogg|All Files (*.*)|*.*";
            ofd1.FilterIndex = 1;
            ofd1.ShowDialog();
            if (ofd1.FileName != "")
            {
                filePath = ofd1.FileName;
                LabelAudio.Text = filePath;

                //var ffMpeg = new FFMpegConverter();
                //ffMpeg.ConvertMedia(@filePath, Directory.GetCurrentDirectory() + "/TempAudio.wav", "wav");

                // Convert the audio file to WAV format using FFmpeg
                var startInfo = new ProcessStartInfo
                {
                    FileName = "ffmpeg",
                    Arguments = $"-i \"{filePath}\" -b:a 64k -compression_level 8 \"{Directory.GetCurrentDirectory()}/TempAudio.mp3\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                process = Process.Start(startInfo);

            }
            else
            {
                filePath = "";
                LabelAudio.Text = "NO AUDIO SELECTED!";
            }
        }

        private void formBtn_Click(object sender, EventArgs e)
        {

            if (int.TryParse(formIntensity.Text, out int result))
            {
                base64 = GenerateWaveform(Directory.GetCurrentDirectory() + "/TempAudio.mp3", result);
            }
            else
            {
                base64 = GenerateWaveform(Directory.GetCurrentDirectory() + "/TempAudio.mp3", 5);
            }
            MessageBox.Show("Wavefront should work!", "WaveForm created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void SendButton_ClickAsync(object sender, EventArgs e)
        {
            if (filePath == "" || LengthBox.Text == "" || ChannelBox.Text == "" || TokenBox.Text == "")
            {
                label5.Text = "ERROR, YOU FORGOT SOMETHING";
                return;
            }
            label5.Text = "SENDING...";
            string fileName = @filePath;
            FileInfo fi = new FileInfo(fileName);
            float fileSize = fi.Length;

            string myJson = "{\"files\": [{\"file_size\": " + fileSize + ", \"filename\": \"voice-message.ogg\", \"id\": \"20\" }]}";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Discord-Android/172024");
                client.DefaultRequestHeaders.Add("authorization", TokenBox.Text);
                client.DefaultRequestHeaders.Add("x-super-properties", "eyJvcyI6IkFuZHJvaWQiLCJicm93c2VyIjoiRGlzY29yZCBBbmRyb2lkIiwiZGV2aWNlIjoibXVuY2giLCJzeXN0ZW1fbG9jYWxlIjoiZnItRlIiLCJjbGllbnRfdmVyc2lvbiI6IjE3Mi4yNCAtIHJuIiwicmVsZWFzZV9jaGFubmVsIjoiZ29vZ2xlUmVsZWFzZSIsImRldmljZV92ZW5kb3JfaWQiOiIzZDk4NGYxYS02NTYwLTQ2ZjktOWZhNy0zNGU2YzEzNmQyNmUiLCJicm93c2VyX3VzZXJfYWdlbnQiOiIiLCJicm93c2VyX3ZlcnNpb24iOiIiLCJvc192ZXJzaW9uIjoiMzMiLCJjbGllbnRfYnVpbGRfbnVtYmVyIjo2OTY5Njk2OTY5Njk2LCJjbGllbnRfZXZlbnRfc291cmNlIjpudWxsLCJkZXNpZ25faWQiOjB9");

                var response = await client.PostAsync(
                    "https://discord.com/api/v9/channels/"+ ChannelBox.Text +"/attachments",
                     new StringContent(myJson, Encoding.UTF8, "application/json"));

                var responseContent = await response.Content.ReadAsStringAsync();

                if (responseContent == null)
                {
                    MessageBox.Show("Discord send back NULL value", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Invalid Token", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //MessageBox.Show(responseContent, "Discord File Uploaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                string uploadUrl = jsonResponse.attachments[0].upload_url;
                string fileNameDiscord = jsonResponse.attachments[0].upload_filename;
                //MessageBox.Show(fileNameDiscord, "Discord New File Name", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (var client2 = new HttpClient())
                {
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/ogg");

                    var putResponse = await client2.PutAsync(uploadUrl, fileContent);
                    if (putResponse.IsSuccessStatusCode)
                    {
                        label5.Text = "FILE SENT... SENDING MESSAGE";
                        Random rand = new Random();
                        int min = 262625563;
                        int max = 862625563;
                        long nonce = rand.Next(min, max);

                        string messageJson = "{\"attachments\":[{\"duration_secs\":" + LengthBox.Text + ",\"filename\":\"voice-message.ogg\",\"id\":\"0\",\"uploaded_filename\":\"" + fileNameDiscord  + "\",\"waveform\":\"" + base64 + "\"}],\"channel_id\":\"" + ChannelBox.Text + "\",\"content\":\"\",\"flags\":8192,\"nonce\":\"" + nonce + "\",\"type\":0}";
                        using (var client3 = new HttpClient())
                        {
                            client3.DefaultRequestHeaders.Add("User-Agent", "Discord-Android/172024");
                            client3.DefaultRequestHeaders.Add("authorization", TokenBox.Text);
                            client3.DefaultRequestHeaders.Add("x-super-properties", "eyJvcyI6IkFuZHJvaWQiLCJicm93c2VyIjoiRGlzY29yZCBBbmRyb2lkIiwiZGV2aWNlIjoibXVuY2giLCJzeXN0ZW1fbG9jYWxlIjoiZnItRlIiLCJjbGllbnRfdmVyc2lvbiI6IjE3Mi4yNCAtIHJuIiwicmVsZWFzZV9jaGFubmVsIjoiZ29vZ2xlUmVsZWFzZSIsImRldmljZV92ZW5kb3JfaWQiOiIzZDk4NGYxYS02NTYwLTQ2ZjktOWZhNy0zNGU2YzEzNmQyNmUiLCJicm93c2VyX3VzZXJfYWdlbnQiOiIiLCJicm93c2VyX3ZlcnNpb24iOiIiLCJvc192ZXJzaW9uIjoiMzMiLCJjbGllbnRfYnVpbGRfbnVtYmVyIjo2OTY5Njk2OTY5Njk2LCJjbGllbnRfZXZlbnRfc291cmNlIjpudWxsLCJkZXNpZ25faWQiOjB9");

                            var messageResponse = await client3.PostAsync(
                                "https://discord.com/api/v9/channels/" + ChannelBox.Text + "/messages",
                                new StringContent(messageJson, Encoding.UTF8, "application/json"));

                            messageResponse.EnsureSuccessStatusCode();

                            label5.Text = "MESSAGE SENT!";
                        }
                    }
                    else
                    {
                        label5.Text = "ERROR, FAILED TO UPLOAD FILE";
                        return;
                    }

                }
            }
            
        }

        private void seeToken_CheckedChanged(object sender, EventArgs e)
        {
            if (seeToken.Checked)
            {
                TokenBox.UseSystemPasswordChar = false;
            }
            else
            {
                TokenBox.UseSystemPasswordChar = true;
            }
        }
    }
}
