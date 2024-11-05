import * as classes from './classes';
const dateInitial = new Date();

const clock = new classes.Clock();

for (let i = 0; i < 123; i++)
{
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

function toMb(input: number) {
    return Math.round(input / 1024 / 1024 * 100) / 100;
}