using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WordArrays : MonoBehaviour
{
    private string[] wordsGeneral = new string[]
    {        
    "abacus", "blizzard", "canyon", "dazzle", "eclipse", "fable", "gazelle", "hollow", "ignite", "jigsaw","kettle", "labyrinth", "mirth", "nectar", "oasis", "paddle", "quartz", "rhythm", "saffron", "tangle",
    "umbra", "vapor", "whisper", "xenon", "yonder", "zealot", "amber", "breeze", "crimson", "delta","ember", "flute", "glimmer", "hazel", "ivory", "juniper", "lagoon", "mosaic", "nova", "orchid",
    "prism", "quiver", "ripple", "silk", "throne", "velvet", "wisp", "zephyr", "arcane", "bubble","cascade", "dawn", "enigma", "flicker", "grove", "harbor", "inspire", "jolt", "knoll", "luster","meadow",
    "nimbus", "opulent", "plume", "quest", "radiant", "spire", "tundra", "vivid", "wander","yearn", "zest", "bounty", "clover", "dune", "essence", "fringe", "gleam", "haven", "iris",
    "jasmine", "lodge", "mural", "nerve", "onyx", "pinnacle", "relic", "sable", "tide", "vantage","whirl", "yoke", "zenith", "blaze", "chime", "drift", "fathom", "gush", "hush", "islet",
    "jasper", "kiosk", "lunar", "marble", "noodle", "obscure", "parch", "quell", "raven", "shimmer","talon", "uphold", "vortex", "wrench", "yacht", "zinc", "altar", "beacon", "cider", "drench",
    "elude", "fathom", "gorge", "haste", "inlet", "jovial", "kernel", "latch", "mirth", "noble","osprey", "plush", "quirk", "roost", "sentry", "truce", "usher", "vista", "weave", "yodel",
    "zipper", "banter", "cobble", "deft", "evoke", "flair", "glean", "hoist", "impel", "jaded","knead", "lunge", "mellow", "nudge", "orbit", "pensive", "quaint", "revel", "scorn", "thrive",
    "unify", "valor", "wince", "yearn", "zesty", "amble", "brisk", "clasp", "douse", "enact","flick", "grasp", "hover", "infer", "jostle", "lapse", "mimic", "notch", "oust", "plead",
    "quash", "rigid", "savor", "tweak", "upset", "vague", "wield", "youth", "zebra", "adorn","bleak", "crave", "dwell", "exalt", "forge", "glide", "hunch", "irk", "jumble", "leash",
    "mourn", "nifty", "ovoid", "prune", "quilt", "roam", "sleek", "trend", "utter", "vital","whack", "yelp", "zonal", "badge", "churn", "drape", "elbow", "freak", "gauge", "heave",
    "inert", "jolly", "knack", "lucid", "mush", "niche", "ozone", "plank", "quack", "reap","scold", "toast", "unite", "vomit", "wafer", "yank", "zesty", "aloft", "brawl", "crisp",
    "ditch", "evict", "flock", "gripe", "hobby", "itch", "jaunt", "lanky", "mirth", "nylon","pact", "quell", "roar", "snare", "tramp", "upend", "vowel", "whiff", "yearn", "zippy",
    "abate", "blush", "clank", "dodge", "erupt", "faint", "gloss", "hatch", "idiom", "jumpy","kiosk", "lodge", "mirth", "noble", "opine", "plumb", "quack", "rival", "scoff", "tread",
    "usher", "vague", "wince", "youth", "zesty", "acrid", "bleed", "clump", "dread", "exact","flank", "gloom", "hoard", "inane", "jolly", "kneel", "lurch", "mirth", "nylon", "pagan",
    "quell", "roost", "snarl", "trend", "upset", "vital", "whack", "yodel", "zonal", "adapt","bloom", "clash", "douse", "enjoy", "flake", "grate", "haste", "ivory", "jumpy", "lance",
    "mirth", "noble", "ovoid", "plush", "quilt", "raven", "sneak", "truce", "upend", "vowel","whiff", "youth", "zebra", "alert", "blunt", "cloak", "drain", "evoke", "flair", "glean",
    "hoist", "impel", "jaded", "knead", "lunge", "mirth", "nudge", "orbit", "pact", "quell","reap", "scorn", "thrive", "unify", "valor", "wield", "yearn", "zesty", "amass", "brave",
    "clasp", "drape", "exact", "flock", "grasp", "hover", "infer", "jolly", "lapse", "mimic","notch", "oust", "plead", "quash", "rigid", "savor", "tweak", "upset", "vague", "whack",
    "yelp", "zonal", "adorn", "bleak", "crave", "dwell", "exalt", "forge", "glide", "hunch","irk", "jumble", "leash", "mourn", "nifty", "ovoid", "prune", "quilt", "roam", "sleek",
    "trend", "utter", "vital", "whiff", "youth", "zebra", "badge", "churn", "drape", "elbow","freak", "gauge", "heave", "inert", "jolly", "knack", "lucid", "mush", "niche", "ozone",
    "plank", "quack", "reap", "scold", "toast", "unite", "vomit", "wafer", "yank", "zesty","aloft", "brawl", "crisp", "ditch", "evict", "flock", "gripe", "hobby", "itch", "jaunt",
    "lanky", "mirth", "nylon", "pact", "quell", "roar", "snare", "tramp", "upend", "vowel","whiff", "yearn", "zippy", "abate", "blush", "clank", "dodge", "erupt", "faint", "gloss",
    "hatch", "idiom", "jumpy", "kiosk", "lodge", "mirth", "noble", "opine", "plumb", "quack","rival", "scoff", "tread", "usher", "vague", "wince", "youth", "zesty", "acrid", "bleed",
    "clump", "dread", "exact", "flank", "gloom", "hoard", "inane", "jolly", "kneel", "lurch","mirth", "nylon", "pagan", "quell", "roost", "snarl", "trend", "upset", "vital", "whack",
    "yodel", "zonal", "adapt", "bloom", "clash", "douse", "enjoy", "flake", "grate", "haste","ivory", "jumpy", "lance", "mirth", "noble", "ovoid", "plush", "quilt", "raven", "sneak",
    "truce", "upend", "vowel", "whiff", "youth", "zebra", "alert", "blunt", "cloak", "drain","evoke", "flair", "glean", "hoist", "impel", "jaded", "knead", "lunge", "mirth", "nudge",
    "orbit", "pact", "quell", "reap", "scorn", "thrive", "unify", "valor", "wield", "yearn","zesty", "amass", "brave", "clasp", "drape", "exact", "flock", "grasp", "hover", "infer",
    "jolly", "lapse", "mimic", "notch", "oust", "plead", "quash", "rigid", "savor", "tweak","upset", "vague", "whack", "yelp", "zonal", "adorn", "bleak", "crave", "dwell", "exalt",
    "forge", "glide", "hunch", "irk", "jumble", "leash", "mourn", "nifty", "ovoid", "prune","quilt", "roam", "sleek", "trend", "utter", "vital", "whiff", "youth", "zebra", "badge",
    "churn", "drape", "elbow", "freak", "gauge", "heave", "inert", "jolly", "knack", "lucid","mush", "niche", "ozone", "plank", "quack", "reap", "scold", "toast", "unite", "vomit",
    "wafer", "yank", "zesty", "aloft", "brawl", "crisp", "ditch", "evict", "flock", "gripe","hobby", "itch", "jaunt", "lanky", "mirth", "nylon", "pact", "quell", "roar", "snare",
    "tramp", "upend", "vowel", "whiff", "yearn", "zippy", "abate", "blush", "clank", "dodge","erupt", "faint", "gloss", "hatch", "idiom", "jumpy", "kiosk", "lodge", "mirth", "noble",
    "opine", "plumb", "quack", "rival", "scoff", "tread", "usher", "vague", "wince", "youth","zesty", "acrid", "bleed", "clump", "dread", "exact", "flank", "gloom", "hoard", "inane",
    "jolly", "kneel", "lurch", "mirth", "nylon", "pagan", "quell", "roost", "snarl", "trend","upset", "vital", "whack", "yodel", "zonal", "adapt", "bloom", "clash", "douse", "enjoy",
    "flake", "grate", "haste", "ivory", "jumpy", "lance", "mirth", "noble", "ovoid", "plush","quilt", "raven", "sneak", "truce", "upend", "vowel", "whiff", "youth", "zebra", "alert",
    "blunt", "cloak", "drain", "evoke", "flair", "glean", "hoist", "impel", "jaded", "knead","lunge", "mirth", "nudge", "orbit", "pact", "quell", "reap", "scorn", "thrive", "unify",
    "valor", "wield", "yearn", "zesty", "amass", "brave", "clasp", "drape", "exact", "flock","grasp", "hover", "infer", "jolly", "lapse", "mimic", "notch", "oust", "plead", "quash",
    "rigid", "savor", "tweak", "upset", "vague", "whack", "yelp", "zonal", "adorn", "bleak","crave", "dwell", "exalt", "forge", "glide", "hunch", "irk", "jumble", "leash", "mourn",
    "nifty", "ovoid", "prune", "quilt", "roam", "sleek", "trend", "utter", "vital", "whiff","youth", "zebra", "badge", "churn", "drape", "elbow", "freak", "gauge", "heave", "inert",
    "jolly", "knack", "lucid", "mush", "niche", "ozone", "plank", "quack", "reap", "scold","toast", "unite", "vomit", "wafer", "yank", "zesty", "aloft", "brawl", "crisp", "ditch",
    "evict", "flock", "gripe", "hobby", "itch", "jaunt", "lanky", "mirth", "nylon", "pact","quell", "roar", "snare", "tramp", "upend", "vowel", "whiff", "yearn", "zippy", "abate",
    "blush", "clank", "dodge", "erupt", "faint", "gloss", "hatch", "idiom", "jumpy", "kiosk","lodge", "mirth", "noble", "opine", "plumb", "quack", "rival", "scoff", "tread", "usher",
    "vague", "wince", "youth", "zesty", "acrid", "bleed", "clump", "dread", "exact", "flank","gloom", "hoard", "inane", "jolly", "kneel", "lurch", "mirth", "nylon", "pagan", "quell",
    "roost", "snarl", "trend", "upset", "vital", "whack", "yodel", "zonal", "adapt", "bloom","clash", "douse", "enjoy", "flake", "grate", "haste", "ivory", "jumpy", "lance", "mirth",
    "noble", "ovoid", "plush", "quilt", "raven", "sneak", "truce", "upend", "vowel", "whiff","youth", "zebra", "alert", "blunt", "cloak", "drain", "evoke", "flair", "glean", "hoist",
    "impel", "jaded", "knead", "lunge", "mirth", "nudge", "orbit", "pact", "quell", "reap","scorn", "thrive", "unify", "valor", "wield", "yearn", "zesty", "amass", "brave", "clasp",
    "drape", "exact", "flock", "grasp", "hover", "infer", "jolly", "lapse", "mimic", "notch","oust", "plead", "quash", "rigid", "savor", "tweak", "upset", "vague", "whack", "yelp",
    "zonal", "adorn", "bleak", "crave", "dwell", "exalt", "forge", "glide", "hunch", "irk","jumble", "leash", "mourn", "nifty", "ovoid", "prune", "quilt", "roam", "sleek", "trend",
    "utter", "vital", "whiff", "youth", "zebra", "badge", "churn", "drape", "elbow", "freak","gauge", "heave", "inert", "jolly", "knack", "lucid", "mush", "niche", "ozone", "plank",
    "quack", "reap", "scold", "toast", "unite", "vomit", "wafer", "yank", "zesty", "aloft","brawl", "crisp", "ditch", "evict", "flock", "gripe", "hobby", "itch", "jaunt", "lanky",
    "mirth", "nylon", "pact", "quell", "roar", "snare", "tramp", "upend", "vowel", "whiff","yearn", "zippy", "abate", "blush", "clank", "dodge", "erupt", "faint", "gloss", "hatch",
    "idiom", "jumpy", "kiosk", "lodge", "mirth", "noble", "opine", "plumb", "quack", "rival","scoff", "tread", "usher", "vague", "wince", "youth", "zesty", "acrid", "bleed", "clump",
    "dread", "exact", "flank", "gloom", "hoard", "inane", "jolly", "kneel", "lurch", "mirth","nylon", "pagan", "quell", "roost", "snarl", "trend", "upset", "vital", "whack", "yodel",
    "zonal", "adapt", "bloom", "clash", "douse", "enjoy", "flake", "grate", "haste", "ivory","jumpy", "lance", "mirth", "noble", "ovoid", "plush", "quilt", "raven", "sneak", "truce",
    "upend", "vowel", "whiff", "youth", "zebra", "alert", "blunt", "cloak", "drain", "evoke","flair", "glean", "hoist", "impel", "jaded", "knead", "lunge", "mirth", "nudge", "orbit",
    "pact", "quell", "reap", "scorn", "thrive", "unify", "valor", "wield", "yearn", "zesty","amass", "brave", "clasp", "drape", "exact", "flock", "grasp", "hover", "infer", "jolly",
    "lapse", "mimic", "notch", "oust", "plead", "quash", "rigid", "savor", "tweak", "upset","vague", "whack", "yelp", "zonal", "adorn", "bleak", "crave", "dwell", "exalt", "forge",
    "glide", "hunch", "irk", "jumble", "leash", "mourn", "nifty", "ovoid", "prune", "quilt","roam", "sleek", "trend", "utter", "vital", "whiff", "youth", "zebra", "badge", "churn",
    "drape", "elbow", "freak", "gauge", "heave", "inert", "jolly", "knack", "lucid", "mush","niche", "ozone", "plank", "quack", "reap", "scold", "toast", "unite", "vomit", "wafer",
    "yank", "zesty", "aloft", "brawl", "crisp", "ditch", "evict", "flock", "gripe", "hobby","itch", "jaunt", "lanky", "mirth", "nylon", "pact", "quell", "roar", "snare", "tramp",
    "upend", "vowel", "whiff", "yearn", "zippy", "abate", "blush", "clank", "dodge", "erupt","faint", "gloss", "hatch", "idiom", "jumpy", "kiosk", "lodge", "mirth", "noble", "opine",
    "plumb", "quack", "rival", "scoff", "tread", "usher", "vague", "wince", "youth", "zesty","acrid", "bleed", "clump", "dread", "exact", "flank", "gloom", "hoard", "inane", "jolly",
    "kneel", "lurch", "mirth", "nylon", "pagan", "quell", "roost", "snarl", "trend", "upset","vital", "whack", "yodel", "zonal", "adapt", "bloom", "clash", "douse", "enjoy", "flake",
    "grate", "haste", "ivory", "jumpy", "lance", "mirth", "noble", "ovoid", "plush", "quilt","raven", "sneak", "truce", "upend", "vowel", "whiff", "youth", "zebra", "alert", "blunt",
    "cloak", "drain", "evoke", "flair", "glean", "hoist", "impel", "jaded", "knead", "lunge","mirth", "nudge", "orbit", "pact", "quell", "reap", "scorn", "thrive", "unify", "valor",
    "wield", "yearn", "zesty", "amass", "brave", "clasp", "drape", "exact", "flock", "grasp","hover", "infer", "jolly", "lapse", "mimic", "notch", "oust", "plead", "quash", "rigid",
    "savor", "tweak", "upset", "vague", "whack", "yelp", "zonal", "adorn", "bleak", "crave","dwell", "exalt", "forge", "glide", "hunch", "irk", "jumble", "leash", "mourn", "nifty",
    "ovoid", "prune", "quilt", "roam", "sleek", "trend", "utter", "vital", "whiff", "youth","zebra", "badge", "churn", "drape", "elbow", "freak", "gauge", "heave", "inert", "jolly",
    "knack", "lucid", "mush", "niche", "ozone", "plank", "quack", "reap", "scold", "toast","unite", "vomit", "wafer", "yank", "zesty", "aloft", "brawl", "crisp", "ditch", "evict",
    "flock", "gripe", "hobby", "itch", "jaunt", "lanky", "mirth", "nylon", "pact", "quell","roar", "snare", "tramp", "upend", "vowel", "whiff", "yearn", "zippy", "abate", "blush",
    "clank", "dodge", "erupt", "faint", "gloss", "hatch", "idiom", "jumpy", "kiosk", "lodge","mirth", "noble", "opine", "plumb", "quack", "rival", "scoff", "tread", "usher", "vague",
    "wince", "youth", "zesty", "acrid", "bleed", "clump", "dread", "exact", "flank", "gloom","hoard", "inane", "jolly", "kneel", "lurch", "mirth", "nylon", "pagan", "quell", "roost",
    "snarl", "trend", "upset", "vital", "whack", "yodel", "zonal", "adapt", "bloom", "clash","douse", "enjoy", "flake", "grate", "haste", "ivory", "jumpy", "lance", "mirth", "noble",
    "ovoid", "plush", "quilt", "raven", "sneak", "truce", "upend", "vowel", "whiff", "youth","zebra", "alert", "blunt", "cloak", "drain", "evoke", "flair", "glean", "hoist", "impel",
    "jaded", "knead", "lunge", "mirth", "nudge", "orbit", "pact", "quell", "reap", "scorn","thrive", "unify", "valor", "wield", "yearn", "zesty", "amass", "brave", "clasp", "drape",
    "exact", "flock", "grasp", "hover", "infer", "jolly", "lapse", "mimic", "notch", "oust","plead", "quash", "rigid", "savor", "tweak", "upset", "vague", "whack", "yelp", "zonal",
    "adorn", "bleak", "crave", "dwell", "exalt", "forge", "glide", "hunch", "irk", "jumble","leash", "mourn", "nifty", "ovoid", "prune", "quilt", "roam", "sleek", "trend", "utter",
    "vital", "whiff", "youth", "zebra", "badge", "churn", "drape", "elbow", "freak", "gauge","heave", "inert", "jolly", "knack", "lucid", "mush", "niche", "ozone", "plank", "quack",
    "reap", "scold", "toast", "unite", "vomit", "wafer", "yank", "zesty", "aloft", "brawl","crisp", "ditch", "evict", "flock", "gripe", "hobby", "itch", "jaunt", "lanky", "mirth",
    "nylon", "pact", "quell", "roar", "snare", "tramp", "upend", "vowel", "whiff", "yearn","zippy", "abate", "blush", "clank", "dodge", "erupt", "faint", "gloss", "hatch", "idiom",
    "jumpy", "kiosk", "lodge", "mirth", "noble", "opine", "plumb", "quack", "rival", "scoff","tread", "usher", "vague", "wince", "youth", "zesty", "acrid", "bleed", "clump", "dread",
    "exact", "flank", "gloom", "hoard", "inane", "jolly", "kneel", "lurch", "mirth", "nylon","pagan", "quell", "roost", "snarl", "trend", "upset", "vital", "whack", "yodel", "zonal",
    "adapt", "bloom", "clash", "douse", "enjoy", "flake", "grate", "haste", "ivory", "jumpy","lance", "mirth", "noble", "ovoid", "plush", "quilt", "raven", "sneak", "truce", "upend",
    "vowel", "whiff", "youth", "zebra", "alert", "blunt", "cloak", "drain", "evoke", "flair","glean", "hoist", "impel", "jaded", "knead", "lunge", "mirth", "nudge", "orbit", "pact",
    "quell", "reap", "scorn", "thrive", "unify", "valor", "wield", "yearn", "zesty", "amass","brave", "clasp", "drape", "exact", "flock", "grasp", "hover", "infer", "jolly", "lapse",
    "mimic", "notch", "oust", "plead", "quash", "rigid", "savor", "tweak", "upset", "vague","whack", "yelp", "zonal", "adorn", "bleak", "crave", "dwell", "exalt", "forge", "glide",
    "hunch", "irk", "jumble", "leash", "mourn", "nifty", "ovoid", "prune", "quilt", "roam","sleek", "trend", "utter", "vital", "whiff", "youth", "zebra", "badge", "churn", "drape",
    "elbow", "freak", "gauge", "heave", "inert", "jolly", "knack", "lucid", "mush", "niche","ozone", "plank", "quack", "reap", "scold", "toast", "unite", "vomit", "wafer", "yank",
    "zesty", "aloft", "brawl", "crisp", "ditch", "evict", "flock", "gripe", "hobby", "itch","jaunt", "lanky", "mirth", "nylon", "pact", "quell", "roar", "snare", "tramp", "upend",
    "vowel", "whiff", "yearn", "zippy", "abate", "blush", "clank", "dodge", "erupt", "faint","gloss", "hatch", "idiom", "jumpy", "kiosk", "lodge", "mirth", "noble", "opine", "plumb",
    "quack", "rival", "scoff", "tread", "usher", "vague", "wince", "youth", "zesty", "acrid","bleed", "clump", "dread", "exact", "flank", "gloom", "hoard", "inane", "jolly", "kneel",
    "lurch", "mirth", "nylon", "pagan", "quell", "roost", "snarl", "trend", "upset", "vital","whack", "yodel", "zonal"};

//
private string[] wordsSpace = new string[]
    {"galaxy","star","planet","moon","asteroid","comet","meteor","nebula","black hole","supernova","pulsar","quasar","orbit","gravity","solar system","sun","heliosphere","constellation","milky way","andromeda","eclipse","lunar"
    ,"solar","atmosphere","exoplanet","satellite","spacecraft","rocket","astronaut","cosmonaut","telescope","observatory","cosmos","universe","big bang","dark matter","dark energy","redshift","blueshift","radiation","cosmic rays"
    ,"magnetosphere","ionosphere","plasma","nebula","cluster","dwarf planet","kuiper belt","oort cloud","asteroid belt","meteorite","crater","tide","apogee","perigee","ellipse","trajectory","propulsion","thruster","payload","launch"
    ,"reentry","space station","module","rover","probe","lander","mission","nasa","esa","roscosmos","spacex","velocity","escape velocity","microgravity","zero gravity","vacuum","interstellar","intergalactic","light year","parsec"
    ,"au","spectrum","photon","wavelength","frequency","infrared","ultraviolet","gamma rays","x rays","astrophysics","cosmology","stellar","planetary","galactic","extraterrestrial","alien","terraforming","habitable","zenith"
    ,"protostar","main sequence","red giant","white dwarf","neutron star","magnetar","brown dwarf","gas giant","terrestrial","ring system","trojans","centaur","binary star","trinary system","globular cluster","open cluster"
    ,"spiral galaxy","elliptical galaxy","irregular galaxy","barred spiral","halo","disk","bulge","core","corona","chromosphere","photosphere","sunspot","flare","prominence","mare","rille","regolith","caldera","rift","fault","volcano"
    ,"cryovolcano","geyser","plains","plateau","canyon","ridge","escarpment","impact basin","dust devil","storm","cloud","jet stream","aurora","van allen belts","bow shock","magnetopause","tail","terminator","albedo","opposition"
    ,"conjuntion","transit","occultation","syzygy","perihelion","aphelion","inclination","eccentricity","semimajor axis","semiminor axis","node","ascending node","descending node","precession","nutation","libration","roche limit"
    ,"hill sphere","lagrange point","trojan point","resonance","shepherd moon","ringlet","gap","division","dust ring","ice ring","debris disk","protoplanetary disk","accretion disk","circumstellar disk","exosphere","thermosphere"
    ,"mesosphere","stratosphere","troposphere","hydrosphere","lithosphere","mantle","crust","dynamo","geodesic","singularity","event horizon","hawking radiation","wormhole","spacetime","relativity","general relativity","special relativity"
    ,"time dilation","length contraction","gravitational wave","graviton","antimatter","positron","neutrino","muon","tachyon","boson","fermion","quark","gluon","higgs boson","cosmic web","filament","wall","void","inflation","recombination"
    ,"decoupling","background radiation","cmb","anisotropy","isotropy","homogeneity","expansion","hubble constant","cosmological constant","lambda","density wave","shock wave","bow wave","tidal force","roche lobe","mass transfer","accretion"
    ,"jet","outflow","wind","solar wind","stellar wind","planetary wind","ion wind","particle","electron","proton","neutron","isotope","fusion","fission","nucleosynthesis","helium flash","carbon burning","oxygen burning","silicon burning"
    ,"collapse","implosion","explosion","nova","hypernova","kilonova","pair instability","chandrasekhar limit","luminosity","magnitude","absolute magnitude","apparent magnitude","bolometric","flux","radiance","irradiance","emissivity"
    ,"reflectivity","absorption","emission","scattering","doppler effect","zeeman effzect","stark effect","photoelectric effect","compton scattering","bremsstrahlung","synchrotron","cherenkov radiation","polarization","interference"
    ,"diffraction","refraction","booster","stage","fairing","nose cone","engine","nozzle","combustor","fuel","oxidizer","cryogenic","hypergolic","solid rocket","liquid rocket","hybrid rocket","ion thruster","plasma thruster","hall thruster"
    ,"vasimr","nuclear propulsion","solar sail","photon sail","magnetic sail","electric sail","parachute","heat shield","ablation","retrograde","prograde","burn","delta v","hohmann transfer","bi elliptic transfer","geostationary"
    ,"geosynchronous","polar orbit","sun synchronous","molniya orbit","tundra orbit","low earth orbit","medium earth orbit","high earth orbit","elliptical orbit","circular orbit","inclined orbit","parking orbit","transfer orbit","docking"
    ,"rendezvous","attitude","yaw","pitch","roll","gimbal","reaction wheel","control moment gyroscope","guidance","navigation","telemetry","command","uplink","downlink","antenna","dish","receiver","transmitter","transponder","beacon"
    ,"signal","bandwidth","latency","bit rate","encryption","decryption","simulator","clean room","assembly","integration","test","launchpad","gantery","umbilical","countdown","ignition","liftoff","max q","staging","separation"
    ,"apogee kick","injection","deorbit","splashdown","touchdown","recovery","capsule","suit","eva","airlock","tether","robotic arm","apollo","gemini","mercury","shuttle","skylab","mir","iss","salyut","tiangong","voyager","pioneer"
    ,"mariner","viking","curiosity","perseverance","opportunity","spirit","sojourner","cassini","huygens","galileo","juno","new horizons","dawn","kepler","tess","hubble","chandra","spitzer","webb","planck","cobe","wmap","rosetta"
    ,"philae","hayabusa","osiris rex","chang e","luna","ranger","surveyor","venera","magellan","mars express","maven","insight","exomars","bepicolombo","psyche","lucy","dart","artemis","orion","sls","starliner","crew dragon","falcon"
    ,"starship","blue origin","virgin galactic","isro","cnsa","jaxa","cnes","dlr","uksa","asi","space force","norad","seti","arecibo","alma","vla","fast","ska","ligo","virgo","geo600","kagra","breakthrough","planetarium","astrolabe"
    ,"sextant","chronometer","ephemeris","almanac","catalog","messier","ngc","ic","barnard","hipparcos","gaia","sdss","2mass","iras","astro","xmm newton","nustar","soho","nadir","azimuth","altitude","declination","right ascension"
    ,"hour angle","celestial pole","equator","ecliptic","solstice","equinox","sidereal","synodic","diurnal","annual","parallax","proper motion","radial velocity","tangential velocity","ephemerides","apochromatic","chromatic aberration"
    ,"refractor","reflector","catadioptric","objective","eyepiece","focal length","aperture","magnification","field of view","seeing","transparency","light pollution","dark sky","star chart","planisphere","astrometry","photometry"
    ,"spectroscopy","interferometry","baseline","fringe","resolution","diffraction limit","angular distance","arcminute","arcsecond","milliarcsecond","degree","radian","steradian","flux density","surface brightness","extinction","airmass"
    ,"zenith distance","horizon","meridian","culmination","opposition","quadrature","elongation","phase","gibbous","crescent","waxing","waning","terminator","libration","shadow","umbra","penumbra","antumbra","annular","total","partial"
    ,"hybrid","saros","metonic","inex","transit","occultation","asterism","bayer","flamsteed","variable star","cepheid","rr lyrae","mira","flare star","eruptive variable","pulsating variable","binary","symbiotic star","cataclysmic variable"
    ,"supernova remnant","planetary nebula","h ii region","association","stream","moving group","supercluster","local group","virgo cluster","coma cluster","fornax cluster","perseus cluster","galactic center","galactic plane"
    ,"zone of avoidance","interarm region","spiral arm","bridge","tidal tail","shell","bubble","pillar","bok globule","herbig haro object","maser","megamaser","starburst","ultraluminous","seyfert","blazar","liner","active galaxy"
    ,"radio galaxy","x ray binary","microquasar","thorne zytkow object","wolf rayet star","o type star","b type star","a type star","f type star","g type star","k type star","m type star","l type star","t type star","y type star","subdwarf"
    ,"giant star","supergiant","hypergiant","blue straggler","horizontal branch","asymptotic giant branch","red clump","blue loop","instability strip","hertzsprung gap","main sequence turnoff","zero age main sequence","metallicity"
    ,"population 1","population 2","population 3","helium star","carbon star","oxygen star","silicon star","iron peak","alpha process","beta decay","neutron capture","r process","s process","p process","rp process","triple alpha"
    ,"cno cycle","proton proton chain","convective zone","radiative zone","tachocline","differential rotation","meridional flow","dynamo effect","magnetic field","polarity","reversal","flux tube","faculae","granulation","spicule"
    ,"filament","plage","supergranulation","coronal loop","coronal hole","coronal mass ejection","helmet streamer","quiet Sun","active region","sunspot cycle","solar maximum","solar minimum","ice giant","hot jupiter","super earth"
    ,"mini neptune","rogue planet","chthonian planet","ocean world","desert planet","lava planet","carbon planet","iron planet","silicate planet","coreless planet","pulsar planet","circumbinary","habitable zone","goldilocks zone"
    ,"snow line","frost line","tidal locking","synchronous rotation","retrograde rotation","obliquity","axial tilt","precession","nutation","resonance","mean motion","orbital period","rotational period","day","year","sidereal day"
    ,"solar day","atmosphere","biosignature","technolsignature","methane","oxygen","nitrogen","water vapor","hydrogen","helium","ozone","cloud deck","haze","aerosols","albedo","greenhouse effect","runaway greenhouse","anti greenhouse"
    ,"ice cap","polar cap","glacier","permafrost","cryosphere","volcanism","tectonics","plate tectonics","hotspot","mantle plume","outgassing","erosion","weathering","dust storm","cyclone","anticyclone","monsoon","precipitation"
    ,"lightning","thunder","magnetism","radiation belt","ring current","ion tail","dust tail","coma","nucleus","meteor shower","radiant","bolide","fireball","micrometeorite","zodiacal light","gegenschein","interplanetary dust"
    ,"micrometeoroid","impact","ejecta","ray","central peak","terraced wall","secondary crater","basin","multi ring basin","palimpsest","graben","scarp","rille","fossa","sulcus","lineament","chaos","macula","facula","patera"
    ,"mons","tholus","vallis","chasma","labyrinthus","undae","planitia","planum","terra","regio","dorsum","rupes","catena","sinus","lacus","mare","oceanus","astrophysics","astrobiology","astrostatistics","astrogeology"
    ,"astrodynamics","celestial mechanics","orbital mechanics","perturbation","n body problem","three body problem","stability","chaos","resonance","secular variation","milankovitch cycles","insolation","radiative forcing"
    ,"equilibrium","heat flux","conduction","convection","radiation","blackbody","graybody","emissivity","stefan boltzmann","wiens law","plancks law","kirchhoffs law","thermodynamics","entropy","enthalpy","free energy"
    ,"partition funtion","quantum","wavefuntion","operator","eigenstate","superposition","entanglement","decoherence","tunneling","uncertainty","pauli exclusion","spin","orbitals","shell","subshell","degeneracy","fine structure"
    ,"hyperfine structure","zeeman splitting","stark splitting","spectral line","emission line","absorption line","continuum","band","profile","broadening","doppler broadening","pressure broadening","natural broadening","voigt profile"
    ,"gaussian profile","lorentzian profile","opacity","optical depth","transmission","attenuation","dispersion","index","birefringence","polarimetry","ellipsometry","multiverse","parallel universe","bubble universe","brane","string"
    ,"membrane","dimension","extra dimension","compactification","calabi yau","supersymmetry","gravition","photino","gluino","wino","zino","axion","inflaton","scalar field","tensor field","vector field","gauge boson","grand unification"
    ,"theory of everything","planck length","planck mass","planck temperature","quantum gravity","loop quantum gravity","string theory","m theory","holographic principle","ads cft","black hole thermodynamics","information paradox","firewall"
    ,"ergosphere","frame dragging","kerr metric","schwarzschild radius","reissner nordstrom","penrose process","blandford znajek","no hair theorem","cosmic censorship","naked singularity","white hole","einstein rosen bridge","exotic matter"
    ,"negative mass","alcubierre drive","warp drive","krasnikov tube","tipler cylinder","closed timelike curve","time travel","causality","chronology protection","fermi paradox","drake equation","great filter","zoo hypothesis","rare earth"
    ,"panspermia","directed panspermia","lithopanspermia","radiopanspermia","dyson sphere","dyson swarm","matrioshka brain","stellar engine","shkadov thruster","nicoll dyson beam","dardashev scale","type one","type two","type three"
    ,"omega point","heat death","big freeze","big crunch","big rip","false vacuum","vaccum decay","bubble nucleation","phase transition","reheating","baryogenesis","leptogenesis","matter antimatter asymmetry","matter antimatter explosion"
    ,"cosmic string","domain wall","monopole","topological defect","primordial black hole","virtual particle","casimir effect","unruh effect","horizon"};


    private string[] wordsMine = new string[]
    {"gold","rush","1849","california","mining","caves","prospector","nugget","claim","stake","pan","panning","sluice","pickaxe","shovel","ore","vein","quartz","dig","excavate","tunnel","shaft","drift","adit","lode","placer","strike",
    "fortune","miner","fortyniner","sutter","marshall","coloma","sierra","nevada","river","stream","creek","gravel","sediment","dust","flake","paydirt","bedrock","tailings","prospecting","assay","smelt","refine","bullion","ingot",
    "assayist","geology","rock","mineral","fossil","formation","outcrop","seam","deposit","alluvial","hardrock","dredge","hydraulic","blast","dynamite","explosive","timber","support","collapse","cavein","ventilation","airshaft","lamp","candle",
    "lantern","headlamp","darkness","stalactite","stalagmite","cavern","grotto","passage","chamber","limestone","granite","sandstone","shale","crust","mantle","fault","fissure","crevice","chasm","abyss","underground","subterranean","depth",
    "overburden","extract","haul","cart","wagon","mule","pack","trail","camp","tent","boomtown","ghosttown","settlement","frontier","pioneer","rushers","migration","journey","overland","ship","steamer","port","sanfrancisco","sacramento",
    "stockton","yuba","feather","american","riverbed","flood","erosion","silt","wash","gulch","canyon","ridge","slope","hill","mountain","valley","plateau","terrain","wilderness","claimjumper","lawless","vigilante","justice","dispute",
    "ownership","deed","title","land","survey","boundary","marker","stakeout","specimen","sample","test","yield","profit","wealth","riches","bank","vault","coin","currency","trade","barter","supply","demand","merchant","store","outfit",
    "gear","equipment","tool","forge","blacksmith","anvil","hammer","chisel","drill","bit","crank","pulley","rope","bucket","hoist","winch","crane","load","trolley","track","rail","orecart","wheelbarrow","labor","work","toil","sweat","exhaustion",
    "danger","hazard","risk","accident","injury","death","burial","grave","cemetery","disease","fever","malaria","scurvy","hardship","survival","endurance","hope","dream","ambition","failure","bankruptcy","loss","abandon","ruin","relic",
    "artifact","history","legacy","story","tale","legend","myth","folklore","adventure","quest","treasure","hunt","map","compass","guide","scout","explorer","discovery","find","unearth","reveal","expose","surface","ground","earth","soil",
    "dirt","mud","clay","stone","boulder","pebble","rubble","debris","waste","slag","heap","pile","mound","dump","discard","saloon","gambling","whiskey","brawl","fight","duel","gun","pistol","rifle","knife","violence","crime","theft","robbery",
    "bandit","outlaw","sheriff","marshal","posse","jail","trial","judge","sentence","punishment","execution","hang","gallows","rope","noose","boom","bust","economy","market","price","value","worth","speculation","investment","gain","collapse",
    "panic","depression","recovery","growth","expansion","population","influx","crowd","rushhour","chaos","order","government","statehood","union","territory","west","expansionism","manifest","destiny","travel","route","path","road","highway",
    "pass","gap","summit","desert","forest","timberline","brush","scrub","wild","bear","deer","wolf","snake","rattler","critter","prey","hunt","trap","fish","trout","salmon","water","spring","well","aquifer","pump","pipe","flow","current",
    "rapids","falls","dam","reservoir","irrigation","dry","drought","duststorm","wind","weather","rain","snow","ice","freeze","thaw","season","springtime","summer","fall","winter","climate","heat","cold","chill","frost","sun","shade","shadow",
    "light","dawn","dusk","night","moon","star","sky","horizon","vista","view","scenery","landscape","nature","beauty","rugged","harsh","barren","fertile","growth","plant","tree","pine","oak","root","branch","leaf","bloom","seed","harvest",
    "crop","field","farm","ranch","cattle","horse","saddle","bridle","rein","spur","ride","gallop","trot","pace","herd","flock","sheep","wool","hide","leather","boot","hat","coat","glove","scarf","cloth","cotton","thread","sew","needle","patch",
    "mend","wear","tear","fray","ragged","tattered","worn","old","new","fresh","young","age","time","day","week","month","year","decade","century","era","period","past","present","future","memory","record","journal","diary","letter","message",
    "news","report","dispatch","telegraph","wire","signal","code","morse","post","mail","delivery","pony","express","stage","coach","driver","passenger","fare","ticket","arrival","departure","delay","schedule","clock","watch","hour","minute",
    "second","tick","tock","bell","ring","sound","echo","noise","silence","quiet","calm","peace","rest","sleep","dream","wake","rise","set","begin","end","start","finish","goal","aim","target","mark","hit","miss","try","effort","push","pull",
    "lift","carry","move","shift","place","spot","location","site","area","region","zone","district","county","town","village","city","street","alley","square","plaza","marketplace","shop","vendor","customer","deal","bargain","haggle","price",
    "cost","fee","charge","pay","wage","earn","income","cash","bill","note","change","penny","dime","nickel","quarter","dollar","silver","copper","metal","alloy","melt","cast","mold","shape","form","figure","size","weight","measure","scale",
    "balance","level","flat","even","smooth","rough","jagged","sharp","dull","edge","point","tip","blade","cut","slice","chop","break","split","crack","shatter","crush","grind","powder","grain","sand","dust","ash","smoke","fire","spark","flame",
    "burn","char","scorch","heat","warm","cool","chill","freeze","melt","thaw","liquid","solid","gas","steam","vapor","mist","fog","cloud","storm","thunder","lightning","strike","bolt","flash","glow","gleam","shine","reflect","glint","sparkle",
    "glitter","luster","sheen","polish","buff","rub","scrub","clean","wash","rinse","soak","wet","damp","dry","wipe","dust","sweep","brush","rake","gather","collect","pile","stack","heap","store","stock","save","keep","hold","grip","clutch",
    "grasp","release","drop","fall","sink","rise","climb","descend","lower","raise","up","down","over","under","through","across","along","around","near","far","close","distant","here","there","where","place","space","room","gap","hole","pit",
    "trench","ditch","channel","groove","furrow","ridge","line","row","column","tier","layer","stratum","bed","sheet","cover","top","bottom","side","front","back","middle","center","core","heart","edge","rim","border","frame","outline","shape",
    "curve","bend","twist","turn","loop","circle","ring","round","square","angle","corner","point","peak","summit","crest","slope","incline","decline","drop","rise","height","depth","length","width","breadth","span","stretch","reach","range",
    "scope","extent","limit","bound","end","finish","close","open","start","begin","first","last","next","prior","before","after","now","then","soon","later","early","late","quick","slow","fast","swift","rapid","pace","speed","hurry","rush",
    "dash","run","walk","step","stride","march","crawl","inch","move","shift","drift","flow","stream","course","path","way","track","trail","route","road","journey","trip","voyage","trek","hike","climb","ascend","descent","fall","plunge","dive",
    "sink","float","swim","wade","ford","cross","bridge","span","link","join","connect","tie","bind","knot","loop","fasten","secure","lock","seal","close","shut","open","free","loose","untie","release","let","go","drop","leave","stay","remain",
    "wait","pause","stop","halt","rest","break","cease","quit","end","done","complete","whole","full","part","piece","bit","scrap","shard","fragment","chunk","slab","block","mass","bulk","load","heap","pile","stack","bunch","group","cluster",
    "set","batch","lot","collection","array","series","line","chain","string","sequence","order","rank","grade","class","type","kind","sort","form","style","mode","manner","way","method","means","plan","scheme","design","pattern","model","example",
    "sample","test","trial","proof","evidence","sign","mark","trace","clue","hint","tip","lead","guide","point","show","tell","say","speak","talk","call","name","label","tag","title","term","word","phrase","line","note","memo","message","story",
    "tale","account","report","record","log","book","page","chapter","verse","line","text","script","write","pen","ink","paper","scroll","map","chart","plan","sketch","draw","paint","color","shade","tone","hue","tint","blend","mix","stir","shake",
    "pour","fill","empty","drain","spill","leak","drip","drop","splash","spray","mist","soak","wet","damp","dry","wipe","clean","clear","pure","fresh","new","old","ancient","aged","worn","used","spent","gone","lost","found","kept","saved","held",
    "owned","had","took","gave","shared","lent","borrowed","owed","paid","bought","sold","traded","swapped","changed","shifted","moved","turned","twisted","bent","curved","shaped","formed","made","built","crafted","forged","cast","molded","set",
    "fixed","placed","laid","put","dropped","left","stayed","stood","sat","rested","lay","slept","dreamed","woke","rose","climbed","reached","arrived","came","went","left","departed","traveled","roamed","wandered","explored","sought","searched",
    "hunted","chased","followed","led","guided","showed","pointed","marked","traced","mapped","charted","planned","aimed","tried","worked","labored","toiled","sweated","struggled","fought","won","lost","gained","earned","kept","held","grew","rose",
    "fell","sank","dropped","lifted","raised","built","mined","dug","panned","washed","found","struck","hit","rich","poor","lucky","unlucky","good","bad","great","small","big","huge","tiny","vast","wide","narrow","deep","shallow","high","low","long",
    "short","near","far","close","open","shut","tight","loose","hard","soft","strong","weak","heavy","light","dark","bright","clear","dim","dull","sharp","smooth","rough","wet","dry","hot","cold","warm","cool","fresh","stale","new","old","young",
    "aged","ripe","raw","pure","mixed","clean","dirty","neat","messy","tidy","wild","tame","calm","stormy","quiet","loud","still","busy","idle","free","bound","safe","risky","sure","doubt","true","false","real","fake","right","wrong","just","unfair",
    "kind","cruel","good","evil","hope","fear","joy","sorrow","love","hate","peace","war","friend","foe","ally","enemy","trust","betray","help","harm","save","lose","win","fail","try","quit","start","stop","go","stay","come","leave","arrive","depart",
    "rise","set","dawn","dusk","day","night","sun","moon","star","sky","earth","land","sea","river","lake","stream","creek","hill","mount","valley","plain","wood","stone","gold","dust","nugget","vein","lode","mine","cave","rock","dig","pan","rush",
    "claim","stake","fortune","boom","bust","town","camp","trail","west","frontier","pioneer","adventure","quest","treasure","find","seek","search","hope","dream","chance","luck","fate","destiny"
    };
    ////
    private int index = -1;
    static int difficultyLevel = 1;
    [SerializeField] private bool generalWords;
    [SerializeField] private bool spaceWords;
    [SerializeField] private bool mineWords;

    private void Start()
    {
        ////////////// General //////////////
        for (int t = 0; t < wordsGeneral.Length; t++)
        {
            string tmp = wordsGeneral[t];
            int r = Random.Range(t, wordsGeneral.Length);
            wordsGeneral[t] = wordsGeneral[r];
            wordsGeneral[r] = tmp;
        }
        ////////////// Space //////////////

        for (int t = 0; t < wordsSpace.Length; t++)
        {
            string tmp = wordsSpace[t];
            int r = Random.Range(t, wordsSpace.Length);
            wordsSpace[t] = wordsSpace[r];
            wordsSpace[r] = tmp;
        }
        ////////////// Mine //////////////
        
        for (int t = 0; t < wordsMine.Length; t++)
        {
            string tmp = wordsMine[t];
            int r = Random.Range(t, wordsMine.Length);
            wordsMine[t] = wordsMine[r];
            wordsMine[r] = tmp;
        }
    }

    public string DispenseWord()
    {
        if (generalWords)
        {
            index++;
            return wordsGeneral[index];
        }
        if (spaceWords)
        {
            index++;
            return wordsSpace[index];
        }
        if (mineWords)
        {
            index++;
            return wordsMine[index];
        }
        return null;   
    }

    public void SetDifficultyLevel(int level)
    {
        difficultyLevel = level;
    }
}