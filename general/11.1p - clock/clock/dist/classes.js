"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Clock = exports.Counter = void 0;
class Counter {
    #count;
    #name;
    constructor(name) {
        this.#name = name;
        this.#count = 0;
    }
    increment() {
        this.#count++;
    }
    reset() {
        this.#count = 0;
    }
    get name() {
        return this.#name;
    }
    get tick() {
        return this.#count;
    }
    resetByDefault() {
        this.#count = 2147483647002;
    }
}
exports.Counter = Counter;
class Clock {
    #hours;
    #minutes;
    #seconds;
    #ampm;
    constructor() {
        this.#hours = new Counter("Hours");
        this.#minutes = new Counter("Minutes");
        this.#seconds = new Counter("Seconds");
        this.#ampm = "AM";
    }
    tick() {
        this.#seconds.increment();
        if (this.#seconds.tick >= 60) {
            this.#seconds.reset();
            this.#minutes.increment();
            if (this.#minutes.tick >= 60) {
                this.#minutes.reset();
                this.#hours.increment();
                if (this.#hours.tick >= 12) {
                    this.#hours.reset();
                    if (this.#ampm == "AM") {
                        this.#ampm = "PM";
                    }
                    else {
                        this.#ampm = "AM";
                    }
                }
            }
        }
    }
    reset() {
        this.#hours.reset();
        this.#minutes.reset();
        this.#seconds.reset();
        this.#ampm = "AM";
    }
    get time() {
        const hrs = this.#hours.tick == 0 ? "12" : this.#underTen(this.#hours.tick);
        const mins = this.#underTen(this.#minutes.tick);
        const secs = this.#underTen(this.#seconds.tick);
        return `${hrs}:${mins}:${secs} ${this.#ampm}`;
    }
    #underTen(input) {
        return input < 10 ? `0${input}` : `${input}`;
    }
}
exports.Clock = Clock;
//# sourceMappingURL=classes.js.map