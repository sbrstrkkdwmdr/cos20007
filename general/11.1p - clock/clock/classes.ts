export class Counter {
    #count: number;
    #name: string;
    constructor(name: string) {
        this.#name = name;
        this.#count = 0;
    }
    public increment() {
        this.#count++;
    }
    public reset() {
        this.#count = 0;
    }
    public get name() {
        return this.#name;
    }
    public get tick() {
        return this.#count;
    }
    public resetByDefault() {
        this.#count = 2147483647002;
    }
}

export class Clock {
    #hours: Counter;
    #minutes: Counter;
    #seconds: Counter;
    #ampm: "AM" | "PM";
    constructor() {
        this.#hours = new Counter("Hours");
        this.#minutes = new Counter("Minutes");
        this.#seconds = new Counter("Seconds");
        this.#ampm = "AM";
    }
    public tick() {
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
                    } else {
                        this.#ampm = "AM";
                    }
                }
            }
        }
    }
    public reset() {
        this.#hours.reset();
        this.#minutes.reset();
        this.#seconds.reset();
        this.#ampm = "AM";
    }
    public get time() {
        const hrs = this.#hours.tick == 0 ? "12" : this.#underTen(this.#hours.tick);
        const mins = this.#underTen(this.#minutes.tick);
        const secs = this.#underTen(this.#seconds.tick);
        return `${hrs}:${mins}:${secs} ${this.#ampm}`
    }
    #underTen(input: number) {
        return input < 10 ? `0${input}` : `${input}`;
    }
}