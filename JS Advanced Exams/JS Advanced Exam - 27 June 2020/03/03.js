class VeterinaryClinic {
  constructor(clinicName, capacity) {
    this.clinicName = clinicName;
    this.capacity = capacity;
    this.clients = [];
    this.totalProfit = 0;
  }

  newCustomer(ownerName, petName, kind, procedures) {
    this.CapacityExceeded();

    if (
      this.clients[ownerName] !== undefined &&
      this.clients[ownerName].some((x) => x.petName === petName) === true
    ) {
      throw new Error(
        `${customer.firstName} ${customer.lastName} is already our customer!`
      );
    }

    let validPetName = typeof petName === "string";
    let validKind = typeof kind === "string";
    let validProcedures = Array.isArray(procedures);
    if (validPetName && validKind && validProcedures) {
      if (this.clients[ownerName] === undefined) {
        this.clients[ownerName] = [];
      }
      if (
        this.clients[ownerName].some((x) => x.petName === petName) === false
      ) {
        let pet = { petName, kind, procedures };
        this.clients[ownerName].push(pet);
        return `Welcome ${petName}!`;
      } else {
        this.AlreadyRegisteredPet(ownerName, petName);
      }
    }
  }

  AlreadyRegisteredPet(ownerName, petName) {
    throw new Error(
      `This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${this.clients[
        ownerName
      ]
        .find((x) => x.petName == petname)
        .procedures.join(", ")}.`
    );
  }

  CapacityExceeded() {
    if (this.capacity === this.clients.length - 1) {
      throw new Error(`Sorry, we are not able to accept more patients!`);
    }
  }

  onLeaving(ownerName, petName) {
    let doesClientExist = this.clients[ownerName] !== undefined;
    if (!doesClientExist) {
      throw new Error(`Sorry, there is no such client!`);
    }
    let doesPetExistUnderThisClientName =
      this.clients[ownerName].some((x) => x.petName === petName) === true;
    let doesPetHasProcedures = doesClientExist
      ? this.clients[ownerName].find((x) => x.petName === petName).procedures
          .length > 0
      : false;
    if (!doesPetExistUnderThisClientName || !doesPetHasProcedures) {
      throw new Error(`Sorry, there are no procedures for ${petName}!`);
    }
    let procedures = this.clients[ownerName].find((x) => x.petName === petName)
      .procedures;
    this.totalProfit += procedures.length * 500;
    this.clients[ownerName].find((x) => x.petName === petName).procedures = [];
    return `Goodbye ${petName}. Stay safe!`;
  }
  toString() {
    let currentWorkLoad = (this.countProperties(this.clients) / 100) * this.capacity * 100;
    let result = `${this.clinicName} is ${currentWorkLoad}% busy today!`;
    result += `\nTotal profit: ${this.totalProfit.toFixed(2)}$`;
     // {
    //     'David Asenov': [
    //       { petName: 'Tom', kind: 'Cat', procedures: [Array] },
    //       { petName: 'Flufy', kind: 'Cat', procedures: [Array] }
    //     ],
    //     'John Doe': { petName: 'Max', kind: 'Dog', procedures: [ 'D', 'E' ] }
    //   }
    this.clients.sort((a,b)=>{
      a.petName.localeCompare(b.petName)}
      );

    for (const client in this.clients){
      if (this.clients.hasOwnProperty(client)) {
        result+=`\n${client} with:`
        const pets = this.clients[client];
        for (const pet in pets.sort((a,b)=>{
      b.petName.localeCompare(a.petName)}
      )) {
          if (pets.hasOwnProperty(pet)) {
            const petInfo = pets[pet];
            result+=`\n---${petInfo.petName} - a ${petInfo.kind.toLowerCase()} that needs: ${petInfo.procedures.join(', ')}`
          }
        }
      }
    }
    return result;
  }
  countProperties(obj) {
    var count = 0;
    for (var prop in obj) {
      if (obj.hasOwnProperty(prop)) ++count;
    }
    return count;
  }
}

let clinic = new VeterinaryClinic("SoftCare", 10);
console.log(
  clinic.newCustomer("Jim Jones", "Tom", "Cat", ["A154B", "2C32B", "12CDB"])
);
console.log(
  clinic.newCustomer("Anna Morgan", "Max", "Dog", ["SK456", "DFG45", "KS456"])
);
console.log(clinic.newCustomer("Jim Jones", "Tiny", "Cat", ["A154B"]));
console.log(clinic.onLeaving("Jim Jones", "Tiny"));
console.log(clinic.toString());
clinic.newCustomer("Jim Jones", "Sara", "Dog", ["A154B"]);
console.log(clinic.toString());
