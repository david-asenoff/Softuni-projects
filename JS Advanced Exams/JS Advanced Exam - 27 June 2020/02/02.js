function solveClasses() {
    const alreadyAddedcomment = 'This comment is already added!';
    const commentAddedSuccessfuly = 'Comment is added.';
    const specialRequirments = '\nSpecial requirements: ';
    const happyAndPurring = ', happy and purring.';
    const mainInfo = 'Main information:';
    const bewareOfScratches = ', but beware of scratches.';
    const dogMainInfo = 'Main information:\n';
    const happyWingingTail = ', happy and wagging tail.';
    const minCommentLength = 0;
    class Pet {
        constructor(owner, name) {
            this.name = name;
            this.owner = owner;
            this.comments = [];
        }
        toString() {
            var result = `Here is ${this.owner}'s pet ${this.name}.`;
            if (this.comments.length > minCommentLength) {
                result += specialRequirments;
                let temp = this.comments
                    .map((comment) => `${comment}`).join(', ');
                result += temp;
            }
            return result;
        }
        feed() {
            const isFed = `${this.name} is fed`;
            return isFed;
        }
        addComment(comment) {
            if (!this.comments.includes(comment)) {
                this.comments.push(comment);
                return commentAddedSuccessfuly;
            } else {
                throw new Error(alreadyAddedcomment);
            }
        }
    };
    class Dog extends Pet {
        constructor(owner, name, runningNeeds, trainability) {
            super(owner, name);
            this.runningNeeds = runningNeeds;
            this.trainability = trainability;
        }
        toString() {
            return super.toString() + `\n` + dogMainInfo + `${this.name} is a dog with need of ${this.runningNeeds}km running every day and ${this.trainability} trainability.`;
        }
        feed() {
            return super.feed() + happyWingingTail;
        }
    };
    class Cat extends Pet {
        constructor(owner, name, insideHabits, scratching) {
            super(owner, name);
            this.insideHabits = insideHabits;
            this.scratching = scratching;
        }
        toString() {
            let result =
                super.toString() + `\n` + mainInfo + '\n' + `${this.name} is a cat with ${this.insideHabits}`;
            if (this.scratching == true) {
                result += bewareOfScratches;
            }
            return result;
        }
        feed() {
            return super.feed() + happyAndPurring;
        }
    };
    return {
        Pet,
        Dog,
        Cat
    };
}