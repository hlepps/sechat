import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';
import fs from 'fs';
import path from 'path';
import child_process from 'child_process';
import { env } from 'process';



// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin()],
    
    server: {
        port: 5000
    }
})
