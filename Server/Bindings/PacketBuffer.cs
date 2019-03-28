using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bindings
{
    class PacketBuffer : IDisposable
    {
        List<byte> _bufferlist;
        byte[] _readbuffer;
        bool _bufferupdate = false;
        int _readpos;

        public PacketBuffer()
        {
            _bufferlist = new List<byte>();
            _readpos =0;
        }

        public int GetReadPos()
        {
            return _readpos;
        }

        public byte[] ToArray()
        {
            return _bufferlist.ToArray();
        }

        public int Count()
        {
            return _bufferlist.Count();
        }

        public int Length()
        {
            return  Count() - _readpos;
        }

        public void Clear()
        {
            _bufferlist.Clear();
            _readpos = 0;
        }

        // Write Data
        public void WriteBytes(byte[] input)
        {
            _bufferlist.AddRange(input);
            _bufferupdate = true;
        }
        public void WriteByte(byte input)
        {
            _bufferlist.Add(input);
            _bufferupdate = true;
        }
        public void WriteInteger(int input)
        {
            _bufferlist.AddRange(BitConverter.GetBytes(input));
            _bufferupdate = true;
        }
        public void WriteFloat (float input)
        {
            _bufferlist.AddRange(BitConverter.GetBytes(input));
            _bufferupdate = true;
        }
        public void WriteString(string input)
        {
            _bufferlist.AddRange(BitConverter.GetBytes(input.Length));
            _bufferlist.AddRange(Encoding.ASCII.GetBytes(input));
            _bufferupdate = true;
        }

        // Read Data
        public int ReadInteger(bool peek = true)
        {
            if (_bufferlist.Count > _readpos)
            {
                if (_bufferupdate)
                {
                    _readbuffer =_bufferlist.ToArray();
                    _bufferupdate = false;
                }   

                int value = BitConverter.ToInt32(_readbuffer, _readpos);
                if (peek &  _bufferlist.Count > _readpos)
                {
                    _readpos += 4;
                }

                return value;
            }
            else
            {
                throw new Exception("Buffer limit reached");
            }
        }
        public float ReadFloat(bool peek = true)
        {
            if (_bufferlist.Count > _readpos)
            {
                if (_bufferupdate)
                {
                    _readbuffer = _bufferlist.ToArray();
                    _bufferupdate = false;
                }

                float value = BitConverter.ToSingle(_readbuffer, _readpos);
                if (peek & _bufferlist.Count > _readpos)
                {
                    _readpos += 4;
                }

                return value;
            }
            else
            {
                throw new Exception("Buffer limit reached");
            }
        }
        public byte ReadByte(bool peek = true)
        {
            if (_bufferlist.Count > _readpos)
            {
                if (_bufferupdate)
                {
                    _readbuffer = _bufferlist.ToArray();
                    _bufferupdate = false;
                }

                byte value = _readbuffer[_readpos];
                if (peek & _bufferlist.Count > _readpos)
                {
                    _readpos += 1;
                }

                return value;
            }
            else
            {
                throw new Exception("Buffer limit reached");
            }
        }
        public byte[] ReadInteger(int length, bool peek = true)
        {
            
                if (_bufferupdate)
                {
                    _readbuffer = _bufferlist.ToArray();
                    _bufferupdate = false;
                }

                byte[] value = _bufferlist.GetRange(_readpos, length).ToArray();
                if (peek & _bufferlist.Count > _readpos)
                {
                    _readpos += length;
                }
                return value;
        }
        public string ReadString(bool peek = true)
        {
            int length = ReadInteger(true);
            if (_bufferupdate)
            {
                _readbuffer = _bufferlist.ToArray();
                _bufferupdate = false;
            }

            string value = Encoding.ASCII.GetString(_readbuffer, _readpos, length);
            if (peek & _bufferlist.Count > _readpos)
            {
                _readpos += length;
            }

                return value;
            
        }

        //IDisposable
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _bufferlist.Clear();
                }
                _readpos = 0;
            }
            disposedValue = true;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
