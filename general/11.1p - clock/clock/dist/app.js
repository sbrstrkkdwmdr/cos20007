"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
const classes = __importStar(require("./classes"));
const dateInitial = new Date();
const clock = new classes.Clock();
for (let i = 0; i < 123; i++) {
    clock.tick();
}
console.log(clock.time);
const dateFinal = new Date();
const timeTaken = dateFinal.getTime() - dateInitial.getTime();
console.log("\n\nDEBUG INFO ---");
const memoryData = process.memoryUsage();
console.log(`
Execution time: ${timeTaken}ms
RSS: ${toMb(memoryData.rss)} MB
Total Allocated Heap: ${toMb(memoryData.heapTotal)} MB
Memory used: ${toMb(memoryData.heapUsed)} MB
External: ${toMb(memoryData.external)} MB
`);
function toMb(input) {
    return Math.round(input / 1024 / 1024 * 100) / 100;
}
//# sourceMappingURL=app.js.map